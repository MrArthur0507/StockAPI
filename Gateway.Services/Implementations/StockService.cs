using Gateway.Services.Interfaces;
using Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IConfigurationService _config;
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _client;
        public StockService(IConfigurationService config, IHttpClientFactory clientFactory)
        {
            _config = config;
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient();
            _client.BaseAddress = new Uri("http://localhost:5000/api/stocks");
        }

        public async Task<string> GetStockData(Stock stock)
        {
            var response = await _client.GetStringAsync($"?TIME_SERIES_{stock.TimeSeries}&symbol={stock.Symbol}&interval={(int?)stock.Interval}");

            return response;
        }
    }
}
