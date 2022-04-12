using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enverus.VWAPService.Models
{
    public class TradingData
    {
        public DateTime tradedatetimegmt { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }

        public TradingData(DateTime tradedatetimegmt, double open, double high, double low, double close, double volume)
        {
            this.tradedatetimegmt = tradedatetimegmt;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        public override string ToString()
        {
            return $"{tradedatetimegmt}/{open}/{high}/{low}/{close}/{volume}!";
        }
    }
}
