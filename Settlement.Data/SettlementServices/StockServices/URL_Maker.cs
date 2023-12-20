using Stocks.Interfaces;

namespace Settlement.Infrastructure.SettlementServices.StockServices
{
    public class URL_Maker
    {
        private readonly string API_KEY = "VV5H4JTPBS2O605U";

        private readonly string host = "https://www.alphavantage.co/";


        public string GetURL_WithBaseStock(IBaseStock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException("No stock provided , got : " + stock);
            }
            string urlToCall = $"{host}query?function=TIME_SERIES_{stock.TimeSeries}&symbol={stock.Symbol}&interval={(int?)stock.Interval}min&apikey={API_KEY}";
            return urlToCall;
        }


    }
}
