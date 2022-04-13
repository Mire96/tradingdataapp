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


        //Singleton patten for controller
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
            ResetPeriod();

            //Set the current date to a starting point
            DateTime currentDate = tradingDatas[0].tradedatetimegmt;
            AgregateData(tradingDatas[0]);

            //Loop, going through trading data, agregating it and adding period agregates to the result list
            //It goes through every 1 minute period and when it gets to a 10 minute period it calculates VWAP up until that point 
            //and adds the data to the result list
            for (int i = 1; i < tradingDatas.Count; i++)
            {

                //Grab current iteration 1 minute interval
                var currentPeriod = tradingDatas[i];

                //Use this method to agregate the current period 
                AgregateData(currentPeriod);


                //Check if we agregated 10 minutes so far
                if(isPeriodEnded(i, tradingDatas.Count, 10))
                {
                    TradingData td;


                    //Sometimes the api returned 0 trades per period, hence this check is used to check if there is a valid Total Volume.
                    if (totalVolume != 0)
                    {
                        //Calculate vwap according to : https://www.investopedia.com/terms/v/vwap.asp
                        double vwap = pv / totalVolume;

                        //Create new instance of TradingData class to be added to resultTradingData list
                        td = new TradingData(currentPeriod.tradedatetimegmt, Math.Round(tradingDatas[i - 10].open, 2), Math.Round((highSum / currentVolume), 2), Math.Round((lowSum / currentVolume), 2), Math.Round((closeSum / currentVolume), 2), currentVolume);
                        td.vwap = Math.Round(vwap, 2);

                    }
                    else
                    {
                        //If there is no data for total volume, just add the current period to the resultTradingData
                        td = currentPeriod;
                    }

                    //Reset highSum, lowSum and closeSum for the next 10 minute period
                    ResetAgregates();
                    resultTradingData.Add(td);

                }


                //Checking when the data for 1 day has been processed 
                if(currentPeriod.tradedatetimegmt.DayOfYear != currentDate.DayOfYear)
                {
                    //Reset pv and totalVolume, since we have processed the whole day
                    ResetPeriod();
                    currentDate = currentPeriod.tradedatetimegmt;
                }
            }
        }

        //Helper method for checking if a period of trading has been agregated
        //parameter i marks the current period
        //parameter count marks the number of all periods
        //parameter periodSize marks the size of the interval we want to agregate
        private bool isPeriodEnded(int i, int count, int periodSize)
        {
            return i % periodSize == 0 || i + 1 == count;
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


        //Method for reseting variables to 0 after calculations for 10 minute period have been finished
        private void ResetAgregates()
        {
            
            currentVolume = 0;
            highSum = 0;
            lowSum = 0;
            closeSum = 0;
        }


        //Method for reseting varuables to 0 after calculations for 1 whole day
        private void ResetPeriod()
        {
            totalVolume = 0;
            pv = 0;
        }
        #endregion
    }
}
