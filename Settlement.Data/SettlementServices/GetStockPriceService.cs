﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Settlement.Infrastructure.Models.SettlementModels;
using Settlement.API.Controllers.SettlementContracts;

namespace SettlementServices
{
    public class GetStockPriceService : IGetStockPriceService
    {
        public async Task<double> GetStockPrice(string stock)
        {
            var client = new HttpClient();

            JObject data = JsonConvert.DeserializeObject<JObject>(stock);
            JObject timeSeriesDaily = data["Time Series (Daily)"] as JObject;
            JObject DailyStock = timeSeriesDaily[$"{DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd")}"] as JObject;
            if (DateTime.Now.DayOfWeek is DayOfWeek.Sunday)
            {
                 DailyStock = timeSeriesDaily[$"{DateTime.Now.Date.AddDays(-2).ToString("yyyy-MM-dd")}"] as JObject;
            }
            else if (DateTime.Now.DayOfWeek is DayOfWeek.Sunday)
            {
                 DailyStock = timeSeriesDaily[$"{DateTime.Now.Date.AddDays(-3).ToString("yyyy-MM-dd")}"] as JObject;
            }
            StockData stockData = new StockData();
            stockData.Open = DailyStock.Value<double>("1. open");
            stockData.High = DailyStock.Value<double>("2. high");
            stockData.Low = DailyStock.Value<double>("3. low");
            stockData.Close = DailyStock.Value<double>("4. close");
            stockData.Volume = DailyStock.Value<long>("5. volume");

            return stockData.Close;
        }

    }
}
