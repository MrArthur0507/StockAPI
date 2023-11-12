using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SettlementServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using System.Data;
using StockAPI.Database.Interfaces;
using AccountAPI.Data.Models.Implementation;
using Stocks.services;
using Stocks.utils;
using Stocks.Enums;
using Stocks.Interfaces;
using AccountAPI.Data.Models.Interfaces;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Settlement.API.Controllers.SettlementServices;
using Settlement.API.Controllers.SettlementServices.Models;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApiAccountService _apiAccountService;
        private readonly ApiStockService _apiStockService;
        private readonly IDataManager _dataManager;
        private readonly URL_Maker _stockService;
        private readonly StockDataService _stockDataService;

        public TransactionsController(ApiAccountService apiAccountService, ApiStockService apiStockService,
            IDataManager dataManager, URL_Maker stockService, StockDataService stockDataService)
        {
            _apiAccountService = apiAccountService;
            _apiStockService = apiStockService;
            _dataManager = dataManager;

            _stockService = stockService;
            _stockDataService = stockDataService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeTransaction(string accountId, string stockName, TimeSeries timeSeries, Interval interval, int quantity)
        {
            //4d39f99a-e8e8-4fb3-a1f7-7747e9cf9660


            var account = await _apiAccountService.GetAccountByIdAsync(accountId);

            var stock = await _apiStockService.GetStockByName(new Stocks.Models.Stock(timeSeries, stockName, interval));


            var client = new HttpClient();



            //HttpResponseMessage response = await client.GetAsync(stock);
            //response.EnsureSuccessStatusCode();


            //string jsonString = await response.Content.ReadAsStringAsync();


            JObject data = JsonConvert.DeserializeObject<JObject>(stock);
            JObject timeSeriesDaily = data["Time Series (Daily)"] as JObject;
            JObject DailyStock = timeSeriesDaily[$"{DateTime.Now.Date.AddDays(-2).ToString("yyyy-MM-dd")}"] as JObject;



            StockData stockData = new StockData();
            stockData.Open = DailyStock.Value<double>("1. open");
            stockData.High = DailyStock.Value<double>("2. high");
            stockData.Low = DailyStock.Value<double>("3. low");
            stockData.Close = DailyStock.Value<double>("4. close");
            stockData.Volume = DailyStock.Value<long>("5. volume");



            //timeSeries : INTRADAY
            //stockName: MSFT
            //interval: 60




            //var newTransaction = new AccountAPI.Data.Models.Implementation.Transaction();
            //_dataManager.InsertData(newTransaction);

            //account.Balance -= Convert.ToDecimal(stockData.Close);

            //_dataManager.UpdateData(account, accountId);
            //return Ok(newTransaction);



            string connectionString = "Server=(Local)\\SQLEXPRESS01;Database=StockApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL operations will go here.


                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    // Define your SQL query
                    string sqlQuery = "INSERT INTO Transactions (Account, Stock, Date, Price, Quantity, Id) VALUES (@AccountId, @StockName, @Date, @Price, @Quantity, @Id)";
                    command.CommandText = sqlQuery;



                    command.Parameters.AddWithValue("@AccountId", account.Id);
                    command.Parameters.AddWithValue("@StockName", stockName);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@Price", stockData.Close);
                    command.Parameters.AddWithValue("Quantity", quantity);
                    //command.Parameters.AddWithValue("@Id", );



                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check rowsAffected to see if the operation was successful
                }
            }

        

    

            return Ok(stock);
        }
    }
}
