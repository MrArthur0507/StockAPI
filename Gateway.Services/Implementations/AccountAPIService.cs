using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AccountAPIService : IAccountAPIService
    {
        private readonly IConfigurationService _configService;
        private readonly IHttpClientFactory _clientFactory;
        private IConfig _config;
        private HttpClient _client;

        public AccountAPIService(IConfigurationService configurationService, IHttpClientFactory clientFactory)
        {
            _configService = configurationService;
            _config = _configService.GetAppSettings();
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient();
            _client.BaseAddress = new Uri(_config.AccountConfig.Host);
        }

        public async Task<string> GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + _config.AccountConfig.GetAll);
            return await HandleResponse(response);
        }

        public async Task<string> GetById(string id)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + _config.AccountConfig.GetById + "?id=" + id);
            return await HandleResponse(response);
        }

        public async Task<int> Register(string username, string password, string email, string balance)
        {
            

            var parameters = new Dictionary<string, string> { { "username", username }, { "password", password },
            {"email", email }, {"balance", balance } };

            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}{_config.AccountConfig.CreateAccount}", encodedContent);

            return (int)response.StatusCode;
        }

        public async Task<string> Login(string email, string password)
        {
            var parameters = new Dictionary<string, string> { { "email", email }, { "password", password } };

            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}{_config.AccountConfig.Login}", encodedContent);
            
            return GetJwtToken(response);
        }

        private string GetJwtToken(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("Set-Cookie", out var cookieValues))
            {
                return cookieValues.FirstOrDefault();
            }
            return null;
        }

        private async Task<string> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "Error";
        }
    }
}
