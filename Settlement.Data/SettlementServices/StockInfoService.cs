using Settlement.API.Controllers.SettlementServices;
using SettlementServices;
using Settlement.Infrastructure.Models.StockModels;
using Settlement.Infrastructure.Models.StockModels;
using Settlement.Infrastructure.SettlementServices.StockServices;
using Settlement.API.Controllers.SettlementContracts;

namespace Settlement.Infrastructure.SettlementServices
{
    public class StockInfoService : IStockInfoService
    {
        private readonly URL_Maker _stockService;
        private readonly StockDataService _stockDataService;
        private readonly ApiStockService _apiStockService;

        public StockInfoService(ApiStockService apiStockService, URL_Maker stockService, StockDataService stockDataService)
        {
            _stockService = stockService;
            _stockDataService = stockDataService;
            _apiStockService = apiStockService;
        }

        public async Task<string> GetStock(string stockName, TimeSeries timeSeries, Interval interval, int quantity)
        {
            var stock = await _apiStockService.GetStockByName(new Stocks.Models.Stock(timeSeries, stockName, interval));
            return stock;
        }
    }
}
