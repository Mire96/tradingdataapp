using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enverus.VWAPService.Models
{

    //Helper classes for consuming Json data
    public class JsonData
    {
        public ResultData results { get; set; }
    }

    public class ResultData
    {

        public List<TradingData> items { get; set; }
    }
}
