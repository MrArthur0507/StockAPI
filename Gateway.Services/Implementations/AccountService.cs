using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AccountService : IAccountsService
    {
        private readonly IConfigurationService _configService;
        private IConfig _config;
        private readonly HttpClient _client;
        
        public AccountService(IConfigurationService configurationService, HttpClient client) {
            _configService = configurationService;
            _client = client;
            _config = _configService.GetAppSettings();
            _client.BaseAddress = new Uri("http://localhost:5000");
        }
        
        public async Task<string> GetAll()
        {
           // _client.BaseAddress = new Uri("http://localhost:5000");
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + _config.AccountConfig.GetAll);
            Console.Write(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                
                string jsonResponse = await response.Content.ReadAsStringAsync();
                
                return jsonResponse;
            }
            return "Error";
        }

        public async Task<string> GetById(string id)
        {
           // _client.BaseAddress = new Uri("https://localhost:7168");
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + _config.AccountConfig.GetById + "?id=" + id);
            Console.Write(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
            }
            return "Failed";
        }

        public async Task<int> Register(string username, string password, string email, string balance)
        {
            var parameters = new Dictionary<string, string> { { "username", username }, { "password", password },
                {"email", email }, {"balance", balance } };
            
            var encodedContent = new FormUrlEncodedContent(parameters);

            
            HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}{_config.AccountConfig.CreateAccount}",encodedContent);


            return (int)response.StatusCode;
        }
    }
}
