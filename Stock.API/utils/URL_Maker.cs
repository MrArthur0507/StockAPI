using Stocks.Interfaces;
using Stocks.Models;

namespace Stocks.utils
{
    public class URL_Maker
    {
        private readonly string API_KEY = "VV5H4JTPBS2O605U";
        //private readonly string API_KEY2 = "W6MCY7313Y5TG0PP";


        private readonly string api = "https://www.alphavantage.co/";


        public string GetURL(IBaseStock stock)
        {
            if (stock == null)
            {
                throw new ArgumentException("Stock cannot be null", nameof(stock));
            }
            string urlToCall = $"{api}query?function=TIME_SERIES_{stock.TimeSeries}&symbol={stock.Symbol}&interval={(int?)stock.Interval}min&apikey={API_KEY}";
            return urlToCall;
        }


    }
}