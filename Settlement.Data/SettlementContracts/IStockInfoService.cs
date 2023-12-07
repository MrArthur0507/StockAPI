using Settlement.Infrastructure.Models.StockModels;

namespace Settlement.API.Controllers.SettlementContracts
{
    public interface IStockInfoService
    {
        public Task<string> GetStock(string stockName, TimeSeries timeSeries, Interval interval, int quantity);
    }
}
