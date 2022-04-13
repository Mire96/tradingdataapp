using System;
using System.Collections.Generic;
using System.Linq;
// These were added
using System.Net.Http;
using System.Net.Http.Headers;
// These were added
using System.Text;
using System.Threading.Tasks;

namespace Enverus.VWAPService.APIConnection
{
    //Class for the Http client
    public static class APIHandler
    {
        public static HttpClient client { get; set; }

        public static void InitializeClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
            //Setting up the base uri
            client.BaseAddress = new Uri("https://webservice.gvsi.com/query/json/GetIntraday/tradedatetimegmt/open/high/low/close/volume");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Setting up Basic Authentification
            var credentials = Encoding.UTF8.GetBytes("desktopapp:ThePa55word!");
            string val = Convert.ToBase64String(credentials);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
        }
    }
}
