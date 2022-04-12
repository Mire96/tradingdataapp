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
            return tradingDatas;
        }
        #endregion
    }
}
