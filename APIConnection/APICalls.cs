using Enverus.VWAPService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Enverus.VWAPService.APIConnection
{
    public class APICalls
    {
        public static async Task<List<TradingData>> GetTradingDatasAsync(string symbol)
        {
            string url = $"?pricesymbol=\"{symbol}\"&daysBack= 3&intradayBarInterval=1";

            using (HttpResponseMessage response = await APIHandler.client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    JsonData jsonData =  await response.Content.ReadAsAsync<JsonData>();

                    List<TradingData> tradingDatas = jsonData.results.items;
                    return tradingDatas;


                }
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
