using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class TransactionAPIService : BaseAPIService, ITransactionAPIService
    {
        public TransactionAPIService(IHttpClientFactory httpClientFactory, IConfigurationService configurationService)
            : base(httpClientFactory, configurationService)
        {
            client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(config.TransactionConfig.Host);
        }

        public async Task<string> GetTransactionForUser(string id)
        {
            HttpResponseMessage response = await GetAsync($"{client.BaseAddress}{config.TransactionConfig.GetTransactionForUser}?id={id}");

            return await HandleResponse(response);
        }

        public async Task<string> GetTransactionByStock(string stockId)
        {
            HttpResponseMessage response = await GetAsync($"{client.BaseAddress}{config.TransactionConfig.GetTransactionByStock}?id={stockId}");

            return await HandleResponse(response);
        }

    }
}
