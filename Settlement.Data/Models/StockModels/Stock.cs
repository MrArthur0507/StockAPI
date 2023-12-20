using Newtonsoft.Json.Converters;
using Settlement.Infrastructure.Models.StockModels;
using StockContracts;
using System.Text.Json.Serialization;

namespace Stocks.Models
{
    public class Stock : IBaseStock
    {
        public SettlementTimeSeries TimeSeries { get; set; }
        public string? Symbol { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SettlementInterval? Interval { get; set; }


        public Stock(SettlementTimeSeries timeSeries ,string symbol,SettlementInterval interval = Settlement.Infrastructure.Models.StockModels.SettlementInterval.OneMin)
        {
            TimeSeries = timeSeries;
            Symbol = symbol;
            Interval = interval;
        }

        public Stock() { }

    }
}
