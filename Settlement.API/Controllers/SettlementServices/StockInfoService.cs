using SettlementServices;
using Stocks.Enums;
using Stocks.utils;
using System.Text;

namespace Settlement.API.Controllers.SettlementServices
{
    public class StockInfoService
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
