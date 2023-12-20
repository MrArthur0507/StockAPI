using Broker.Models.DTO;
using Broker.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Services.Implementation
{
    public class AccountsGetter : IAccountsGetter
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public AccountsGetter(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            client.BaseAddress = new Uri(_configuration.GetRequiredSection("AccountInfoGetterURL").Value);
        }

        public async Task<string> GetAllAccountsAsJson()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
