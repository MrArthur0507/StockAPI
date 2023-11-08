using Stocks.Interfaces;
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

       
        public async Task<string> GetStockData(IBaseStock stock)
        {
            string apiUrl = _urlMaker.GetURL_WithBaseStock(stock);
            var client = _clientFactory.CreateClient();
            var response = await client.GetStringAsync(apiUrl);

            return response;
        }
    }

}
