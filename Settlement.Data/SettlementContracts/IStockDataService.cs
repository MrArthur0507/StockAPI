using Settlement.Infrastructure.Models.SettlementModels;

namespace Settlement.API.Controllers.SettlementContracts
{
    public interface IStockDataService
    {
        public Task<StockData> GetStockDataAsync(string urlString, string symbol);
    }
}
