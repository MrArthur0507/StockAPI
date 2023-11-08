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

        public TransactionsController(ApiAccountService apiAccountService, ApiStockService apiStockService,
            IDataManager dataManager, URL_Maker stockService)
        {
            _apiAccountService = apiAccountService;
            _apiStockService = apiStockService;
            _dataManager = dataManager;

            _stockService = stockService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeTransaction(string accountId, string stockName, TimeSeries timeSeries, Interval interval)
        {
            var account = _dataManager.SelectByID<Account>("Accounts", accountId);
            var stockJsonString = _stockService.GetURL_WithBaseStock(new Stocks.Models.Stock(timeSeries, stockName, interval));

            Stock stock = JsonConvert.DeserializeObject<Stock>(stockJsonString);


            //timeSeries : INTRADAY
            //stockName: MSFT
            //interval: 60

            var newTransaction = new AccountAPI.Data.Models.Implementation.Transaction();
            _dataManager.InsertData(newTransaction);
            
            _dataManager.UpdateData(account, accountId);
            return Ok(newTransaction);
        }
    }
}
