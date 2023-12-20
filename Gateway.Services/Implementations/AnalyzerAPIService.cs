using Gateway.Services.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AnalyzerAPIService : BaseAPIService, IAnalyzerAPIService
    {
        public AnalyzerAPIService(IHttpClientFactory clientFactory, IConfigurationService configurationService)
            : base(clientFactory, configurationService)
        {
            client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(config.AnalyzerConfig.Host);
        }

        public async Task<string> GetBalance(string accountId)
        {
            HttpResponseMessage response = await GetAsync($"{client.BaseAddress}{config.AnalyzerConfig.CurrentProfit}/{accountId}");

            return await HandleResponse(response);
        }

        public async Task<string> PercentageChange(string futureBalance, string accountId)
        {
            HttpResponseMessage response = await GetAsync($"{client.BaseAddress}{config.AnalyzerConfig.PercentageChange}?futureBalance={futureBalance}&accountId={accountId}");
            return await HandleResponse(response);
        }

        public async Task<string> PortfolioRisk(string accountId)
        {
            HttpResponseMessage response = await GetAsync($"{client.BaseAddress}{config.AnalyzerConfig.PortfolioRisk}?userId={accountId}");
            return await HandleResponse(response);
        }

    }
}
