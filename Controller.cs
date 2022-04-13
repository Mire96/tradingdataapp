using Enverus.VWAPService.APIConnection;
using Enverus.VWAPService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enverus.VWAPService
{
    public class Controller
    {
        #region Properties and Constructor

        private static Controller Instance { get; set; }
        private double pv { get; set; }
        private double totalVolume { get; set; }
        private double currentVolume { get; set; }
        private double highSum { get; set; }
        private double lowSum { get; set; }
        private double closeSum { get; set; }

        private DateTime currentDate { get; set; }

        

        private Controller()
        {
            pv = 0;
            totalVolume = 0;
            currentVolume = 0;
            highSum = 0;
            lowSum = 0;
            closeSum = 0;
        }

        public static Controller GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Controller();
            }
            return Instance;
        }


        // Controller method used for calling the webservice and retrieving the trading data based on the passed financial instrument
        // or 'Symbol', after which it calls the CalculateVWAP to agregate the received data and returns it to the UI to be displayed
        internal async Task<List<TradingData>> GetTradingDataAsync(string symbol)
        {

            //API call to get the trading data from the webservice
            List<TradingData> tradingDatas = await APICalls.GetTradingDatasAsync(symbol);
            List<TradingData> resultTradingData = new List<TradingData>();

            CalculateVWAP(tradingDatas, resultTradingData);

            
            return resultTradingData;
        }


        //Method for calculating VWAP and agregating trading data to a 10 minute period
        private void CalculateVWAP(List<TradingData> tradingDatas, List<TradingData> resultTradingData)
        {
            //We reset the helper variables for agregating data
            ResetAgregates();

            //Set the current date to a starting point
            DateTime currentDate = tradingDatas[0].tradedatetimegmt;


            //Loop, going through trading data, agregating it and adding period agregates to the result list
            //It goes through every 1 minute period and when it gets to a 10 minute period it calculates VWAP up until that point 
            //and adds the data to the result list
            for (int i = 0; i < tradingDatas.Count; i++)
            {
                var currentPeriod = tradingDatas[i];

                AgregateData(currentPeriod);

                if(isPeriodEnded(i, tradingDatas.Count, 10))
                {
                    TradingData td;

                    if (totalVolume != 0)
                    {
                        double vwap = pv / totalVolume;
                        td = new TradingData(currentPeriod.tradedatetimegmt, Math.Round(tradingDatas[i - 9].open, 2), Math.Round((highSum / totalVolume), 2), Math.Round((lowSum / totalVolume), 2), Math.Round((closeSum / totalVolume), 2), currentVolume);
                        currentVolume = 0;
                        td.vwap = Math.Round(vwap, 2);

                    }
                    else
                    {
                        td = currentPeriod;
                    }


                    resultTradingData.Add(td);

                }

                if(currentPeriod.tradedatetimegmt.DayOfYear != currentDate.DayOfYear)
                {
                    ResetAgregates();
                    currentDate = currentPeriod.tradedatetimegmt;
                }
            }
        }

        //Helper method for checking if a period of trading has been agregated
        //parameter i marks the current period
        //parameter count marks the number of all periods
        //
        private bool isPeriodEnded(int i, int count, int periodSize)
        {
            return (i + 1) % periodSize == 0 || i + 1 == count;
        }


        //Method for cumulative calculation of various trading data (high, low, close, period volume, total volume and pv)
        private void AgregateData(TradingData currentPeriod)
        {
            highSum += currentPeriod.high * currentPeriod.volume;
            lowSum += currentPeriod.low * currentPeriod.volume;
            closeSum += currentPeriod.close * currentPeriod.volume;
            currentVolume += currentPeriod.volume;
            totalVolume += currentPeriod.volume;
            pv += ((currentPeriod.high + currentPeriod.low + currentPeriod.close) / 3) * currentPeriod.volume;

        }


        //Method for reseting variables to 0 after calculations for 1 period have been finished
        private void ResetAgregates()
        {
            pv = 0;
            totalVolume = 0;
            highSum = 0;
            lowSum = 0;
            closeSum = 0;
        }
        #endregion
    }
}
