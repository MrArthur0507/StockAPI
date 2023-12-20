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
            // handle the url by passing the wanted stock with its props
            string apiUrl = _urlMaker.GetURL(stock);
            // create a client, to make the api call
            var client = _clientFactory.CreateClient();
            //
            //var response = await client.GetStringAsync(apiUrl);
            // get the whole response from the api
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error calling AlphaVantage API. Status code: {response.StatusCode}");
            }
            // then extract body
            string responseBody = await response.Content.ReadAsStringAsync();
            // convert the string with json data into a json object
            JObject jObject = JObject.Parse(responseBody);




            JObject metaData = (JObject)jObject["Meta Data"]!;
            string symbol = (string)metaData["2. Symbol"]!;

            // Find the key that starts with "Time Series" , since it's a different object from the meta data one , 
            // and what we need is the actual stock info
            // timeSeries is the key of our obj and the apiResponse props 
            // are the values of that object
            // for Example : 
            //"2023-11-10": Object { "1. open": "319.9400", "2. high": "329.1000", "3. low": "319.4600", … }


            string timeSeriesKey = jObject.Properties().FirstOrDefault(p => p.Name.Contains("Time Series"))!.Name;
            JObject actualDataObject = (JObject)jObject[timeSeriesKey]!;

            List<ResponseData> apiResponses = new();

            // Extract the stock data we need
            foreach (var pair in actualDataObject ?? throw new ArgumentNullException("No data in the api response , line 53 , got : " + actualDataObject))
            {
                // Extract the date and the corresponding object
                string date = pair.Key;
                if (pair.Value != null)
                {
                    JObject stockData = (JObject)pair.Value;
                    // Extract the other values for the ApiResponse

                    double open = (double)stockData["1. open"]!;
                    double high = (double)stockData["2. high"]!;
                    double low = (double)stockData["3. low"]!;
                    double close = (double)stockData["4. close"]!;
                    double volume = (double)stockData["5. volume"]!;

                    // create an apiResponse object and adding it to the list
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
