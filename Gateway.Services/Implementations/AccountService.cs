using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AccountService : IAccountsService
    {
        private readonly IConfigurationService _configService;
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfig _config;
        private HttpClient client;
        public AccountService(IConfigurationService configurationService, IHttpClientFactory httpClientFactory) {
            _configService = configurationService;
            _httpClientFactory= httpClientFactory;
            _config = _configService.GetAppSettings();
            client = _httpClientFactory.GetAccountClient();
        }

        public async Task<string> GetPlayers()
        {
            HttpResponseMessage response = await client.GetAsync(_config.AccountConfig.GetAll);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
        
    }
}
