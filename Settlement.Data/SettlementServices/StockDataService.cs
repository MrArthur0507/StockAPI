using Newtonsoft.Json;
using Settlement.API.Controllers.SettlementContracts;
using Settlement.Infrastructure.Models.SettlementModels;
using System.Net.Http;

namespace Settlement.API.Controllers.SettlementServices
{
    public class StockDataService : IStockDataService
    {
        //private readonly HttpClient _httpClient;

        //public StockDataService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}


        public async Task<StockData> GetStockDataAsync(string urlString, string symbol)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{urlString}");
            var apiKey = "YourAlphaVantageApiKey";
            var endpoint = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}";

            HttpResponseMessage response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var stockData = JsonConvert.DeserializeObject<StockData>(json);
                return stockData;
            }
            else
            {
                
                return null;
            }
        }
    }
}
