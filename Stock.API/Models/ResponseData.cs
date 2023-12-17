
using Stocks.Enums;
using System.ComponentModel.DataAnnotations;

namespace Stocks.Models
{
    public class ResponseData
    {
        [Key]
        public Guid Id { get; set; }

        public TimeSeries? TimeSeries { get; set; }
        public string? Symbol { get; set; }
        public string? Date { get; set; }
        public double? Open { get; set; }
        public double? High { get; set; }
        public double? Low { get; set; }
        public double? Close { get; set; }
        public double Volume { get; set; }

        public ResponseData(TimeSeries timeSeries, string symbol, string date, double open, double high, double low, double close, double volume)
        {
            Id = Guid.NewGuid();
            TimeSeries = timeSeries;
            Symbol = symbol;
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }
        public ResponseData() { }
    }
}
