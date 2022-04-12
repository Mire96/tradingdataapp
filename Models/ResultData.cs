using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Enverus.VWAPService.Models
{
    public class ResultData
    {
        
        public List<TradingData> items { get; set; }
    }
}
