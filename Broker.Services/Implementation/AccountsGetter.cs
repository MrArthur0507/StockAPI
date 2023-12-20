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
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        public AccountsGetter(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient();
            _configuration = configuration;
            
        }

        public async Task<string> GetAllAccountsAsJson()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_configuration.GetRequiredSection("AccountInfoGetterURL").Value);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
