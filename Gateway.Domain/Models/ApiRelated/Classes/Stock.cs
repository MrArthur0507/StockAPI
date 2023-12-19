using Gateway.Domain.Models.ApiRelated.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gateway.Domain.Models.ApiRelated.Classes
{
    public class Stock
    {
        public TimeSeries TimeSeries { get; set; }
        public string? Symbol { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Interval? Interval { get; set; }


        public Stock(TimeSeries timeSeries, string symbol, Interval interval = Enums.Interval.OneMin)
        {
            TimeSeries = timeSeries;
            Symbol = symbol;
            Interval = interval;
        }

        public Stock() { }
    }
}
