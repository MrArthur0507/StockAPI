using Newtonsoft.Json.Linq;
using Stocks.Interfaces;
using Stocks.Models;
using Stocks.utils;

namespace Stocks.services
{

    public class AlphaVantageService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly URL_Maker _urlMaker;

        public AlphaVantageService(IHttpClientFactory clientFactory, URL_Maker urlMaker)
        {
            _clientFactory = clientFactory;
            _urlMaker = urlMaker;
        }


        public async Task<List<ResponseData>> GetStockData(IBaseStock stock)
        {
            string apiUrl = _urlMaker.GetURL(stock);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error calling AlphaVantage API. Status code: {response.StatusCode}");
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(responseBody);




            JObject metaData = (JObject)jObject["Meta Data"]!;
            string symbol = (string)metaData["2. Symbol"]!;

            


            string timeSeriesKey = jObject.Properties().FirstOrDefault(p => p.Name.Contains("Time Series"))!.Name;
            JObject actualDataObject = (JObject)jObject[timeSeriesKey]!;

            List<ResponseData> apiResponses = new();

            foreach (var pair in actualDataObject ?? throw new ArgumentNullException("No data in the api response , line 53 , got : " + actualDataObject))
            {
                string date = pair.Key;
                if (pair.Value != null)
                {
                    JObject stockData = (JObject)pair.Value;

                    double open = (double)stockData["1. open"]!;
                    double high = (double)stockData["2. high"]!;
                    double low = (double)stockData["3. low"]!;
                    double close = (double)stockData["4. close"]!;
                    double volume = (double)stockData["5. volume"]!;

                    ResponseData apiResponse = new(stock.TimeSeries, symbol, date, open, high, low, close, volume);
                    apiResponses.Add(apiResponse);
                }
                else
                {
                    throw new ArgumentNullException("The value in alpha vatange return object is null , got : " + pair.Value);
                }






            }

            return apiResponses;
        }

    }

}
