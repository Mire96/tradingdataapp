using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enverus.VWAPService.Models
{

    //Class for consuming JSON from request
    public class TradingData
    {
        public DateTime tradedatetimegmt { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
        public double vwap { get; set; }

        //Text formating property
        public int space { get; set; }



        public TradingData(DateTime tradedatetimegmt, double open, double high, double low, double close, double volume)
        {
            this.tradedatetimegmt = tradedatetimegmt;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
            space = 8;
        }



        public override string ToString()
        {
            return String.Format($"{{0,-{space} }} | {{1,-{space} }} | {{2,-{space} }} | {{3,-{space} }} | {{4,-{space} }} | {{5,-{space} }} | {{6,-{space} }}",
                tradedatetimegmt, open, high, low, close, volume, vwap);
        
        
        }
    }
}
