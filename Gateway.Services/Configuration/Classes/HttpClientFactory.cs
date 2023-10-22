using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Configuration.Classes
{
    public class HttpClientFactory : IHttpClientFactory
    {
        
        private HttpClient _httpClient;
        private IConfigurationService _configuration;
        private IConfig config;
        public HttpClientFactory(HttpClient httpClient, IConfigurationService configuration) {
            _httpClient= httpClient;
            _configuration= configuration;
            config = _configuration.GetAppSettings();
        }
        
        public HttpClient GetAccountClient() {

            _httpClient.BaseAddress = new Uri(config.AccountConfig.Host);
            return _httpClient;
        }

        public HttpClient GetStockClient()
        {
            _httpClient.BaseAddress = new Uri(config.StockConfig.Host);

            return _httpClient;
        }

        public HttpClient GetAnalyzerClient()
        {
            _httpClient.BaseAddress = new Uri(config.AnalyzerConfig.Host);

            return _httpClient;
        }
    }
}
