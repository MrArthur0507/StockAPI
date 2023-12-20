using Gateway.Domain.Models.ApiRelated.Classes;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class StockAPIService : BaseAPIService, IStockAPIService
    {
        public StockAPIService(IHttpClientFactory clientFactory, IConfigurationService configurationService)
            : base(clientFactory, configurationService)
        {
            client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(config.StockConfig.Host);
        }

        public async Task<string> GetStockData(Stock stock)
        {
            var response = await GetAsync($"api/stocks?TIME_SERIES_{stock.TimeSeries}&symbol={stock.Symbol}&interval={(int?)stock.Interval}");
            
            return await HandleResponse(response);
        }

    }
}
