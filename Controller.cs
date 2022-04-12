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

        private Controller()
        {
        }

        public static Controller GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Controller();
            }
            return Instance;
        }

        internal async Task<List<TradingData>> GetTradingDataAsync(string symbol)
        {
            List<TradingData> tradingDatas = await APICalls.GetTradingDatasAsync(symbol);
            List<TradingData> resultTradingData = new List<TradingData>();

            CalculateVWAP(tradingDatas, ref resultTradingData);

            
            return resultTradingData;
        }

        private void CalculateVWAP(List<TradingData> tradingDatas, ref List<TradingData> resultTradingData)
        {
            double pv = 0;
            double totalVolume = 0;
            double highSum = 0;
            double lowSum = 0;
            double closeSum = 0;

            for (int i = 0; i < tradingDatas.Count; i++)
            {
                var currentPeriod = tradingDatas[i];
                highSum += currentPeriod.high * currentPeriod.volume;
                lowSum += currentPeriod.low * currentPeriod.volume;
                closeSum += currentPeriod.close * currentPeriod.volume;
                totalVolume += currentPeriod.volume;

                pv += ((currentPeriod.high + currentPeriod.low + currentPeriod.close) / 3)*currentPeriod.volume;

                if((i+1)%10 == 0)
                {
                    double vwap = pv / totalVolume;
                    TradingData td = new TradingData(currentPeriod.tradedatetimegmt, tradingDatas[i - 9].open, Math.Round((highSum / totalVolume),2), Math.Round((lowSum / totalVolume),2), Math.Round((closeSum / totalVolume),2), totalVolume);
                    td.vwap = Math.Round(vwap,2);
                    resultTradingData.Add(td);

                    pv = 0;
                    totalVolume = 0;
                    highSum = 0;
                    lowSum = 0;
                    closeSum = 0;
                }
            }
        }
        #endregion
    }
}
