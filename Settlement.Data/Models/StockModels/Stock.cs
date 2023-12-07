using Newtonsoft.Json.Converters;
using Settlement.Infrastructure.Models.StockModels;
using StockContracts;
using System.Text.Json.Serialization;

namespace Stocks.Models
{
    public class Stock : IBaseStock
    {
        public TimeSeries TimeSeries { get; set; }
        public string? Symbol { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Interval? Interval { get; set; }


        public Stock(TimeSeries timeSeries ,string symbol,Interval interval = Enums.Interval.OneMin)
        {
            TimeSeries = timeSeries;
            Symbol = symbol;
            Interval = interval;
        }

        public Stock() { }

    }
}
