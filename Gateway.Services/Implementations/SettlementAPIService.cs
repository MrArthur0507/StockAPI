using Gateway.Domain.Models.ApiRelated.Classes;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class SettlementAPIService : BaseAPIService, ISettlementAPIService
    {
        public SettlementAPIService(IHttpClientFactory httpClientFactory, IConfigurationService configurationService)
            : base(httpClientFactory, configurationService)
        {
            client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5158");
        }

        public async Task<string> MakeTransaction(Transaction transaction)
        {

            var parameters = new Dictionary<string, string> { {"accountId", transaction.AccountId },
                { "stockName", transaction.StockName},
                { "timeSeries", transaction.TimeSeries.ToString()},
                { "interval", transaction.Interval.ToString() },
                { "quantity", transaction.Quantity.ToString()} };
            HttpResponseMessage response = await PostAsync(client.BaseAddress.ToString(), parameters);

            return await HandleResponse(response);
        }
    }
}
