using Stocks.Enums;

namespace Stocks.Interfaces
{
    public interface IBaseStock
    {
        public TimeSeries TimeSeries { get; set; }
        public string? Symbol { get; set; }
        public Interval? Interval { get; set; }
    }
}
