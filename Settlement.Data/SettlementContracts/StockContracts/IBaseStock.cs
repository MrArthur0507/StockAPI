using Settlement.Infrastructure.Models.StockModels;

namespace StockContracts;

public interface IBaseStock
{
    public SettlementTimeSeries TimeSeries { get; set; }
    public string? Symbol { get; set; }
    public SettlementInterval? Interval { get; set; }
}
