using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SettlementServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using System.Data;
using StockAPI.Database.Interfaces;
using Stocks.services;
using Stocks.utils;
using Stocks.Enums;
using Stocks.Interfaces;
using AccountAPI.Data.Models.Interfaces;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Settlement.API.Controllers.SettlementServices;
using Settlement.API.Controllers.SettlementServices.Models;
using Settlement.API.Controllers.Data.Models;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        //private readonly ApiAccountService _apiAccountService;
        //private readonly ApiStockService _apiStockService;
        //private readonly IDataManager _dataManager;
        //private readonly URL_Maker _stockService;
        //private readonly StockDataService _stockDataService;


        private readonly AccountInfoService _accountInfoService;
        private readonly StockInfoService _stockInfoService;
        private readonly GetStockPriceService _getStockPriceService;
        private readonly SqliteService _sqliteService;

        public TransactionsController(ApiAccountService apiAccountService, ApiStockService apiStockService,
            IDataManager dataManager, URL_Maker stockService, StockDataService stockDataService, AccountInfoService accountInfoService,
            StockInfoService stockInfoService, GetStockPriceService getStockPriceService, SqliteService sqliteService)
        {
            //_apiAccountService = apiAccountService;
            //_apiStockService = apiStockService;
            //_dataManager = dataManager;

            //_stockService = stockService;
            //_stockDataService = stockDataService;

            _accountInfoService = accountInfoService;
            _stockInfoService = stockInfoService;
            _getStockPriceService = getStockPriceService;

            _sqliteService = sqliteService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeTransaction(string accountId, string stockName, TimeSeries timeSeries, Interval interval, int quantity)
        {
            //4d39f99a-e8e8-4fb3-a1f7-7747e9cf9660

            var account =   _accountInfoService.GetAccount(accountId);
            var stock =  _stockInfoService.GetStock(stockName, timeSeries, interval, quantity);
            var stockPrice =  _getStockPriceService.GetStockPrice(stock.ToString());
            await _sqliteService.AddTransaction(account, stockPrice, quantity, stockName);



            //string dbFilePath = "D:\\Games\\StockAPI\\Settlement.SqliteDb\\AccountTransactions.db";

            //string textFilePath = "D:\\Games\\StockAPI\\Settlement.SqliteDb\\AccountTransactions.txt";



            //SqliteService exporter = new SqliteService(dbFilePath);
            //exporter.ExportDataToTextFile(textFilePath);



            //var account = await _apiAccountService.GetAccountByIdAsync(accountId);

            //var stock = await _apiStockService.GetStockByName(new Stocks.Models.Stock(timeSeries, stockName, interval));



            //var client = new HttpClient();


            //JObject data = JsonConvert.DeserializeObject<JObject>(stock);
            //JObject timeSeriesDaily = data["Time Series (Daily)"] as JObject;
            //JObject DailyStock = timeSeriesDaily[$"{DateTime.Now.Date.AddDays(-2).ToString("yyyy-MM-dd")}"] as JObject;



            //StockData stockData = new StockData();
            //stockData.Open = DailyStock.Value<double>("1. open");
            //stockData.High = DailyStock.Value<double>("2. high");
            //stockData.Low = DailyStock.Value<double>("3. low");
            //stockData.Close = DailyStock.Value<double>("4. close");
            //stockData.Volume = DailyStock.Value<long>("5. volume");


            //timeSeries : INTRADAY
            //stockName: MSFT
            //interval: 60


            return Ok(stock);
        }
    }
}
