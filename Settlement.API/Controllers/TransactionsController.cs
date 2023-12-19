using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SettlementServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using System.Data;
using StockAPI.Database.Interfaces;
using Stocks.services;
using Stocks.Interfaces;
using AccountAPI.Data.Models.Interfaces;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.SettlementServices;

using Settlement.Infrastructure.Models.StockModels;
using Settlement.Infrastructure.Models.SettlementModels;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly AccountInfoService _accountInfoService;
        private readonly StockInfoService _stockInfoService;
        private readonly GetStockPriceService _getStockPriceService;

        private readonly CheckAccountCreditsService _checkAccountCreditsService;
        private readonly SqliteGetTransactionsService _sqliteGetTransactionsService;
        private readonly SqliteAddTransactionsService _sqliteAddTransactionsService;

        public TransactionsController(AccountInfoService accountInfoService,
            StockInfoService stockInfoService, GetStockPriceService getStockPriceService,
            CheckAccountCreditsService checkAccountCreditsService, 
            
            SqliteAddTransactionsService sqliteAddTransactionsService,
            SqliteGetTransactionsService sqliteGetTransactionsService
            )
        {

            _accountInfoService = accountInfoService;
            _stockInfoService = stockInfoService;
            _getStockPriceService = getStockPriceService;
            _checkAccountCreditsService= checkAccountCreditsService;
            _sqliteAddTransactionsService = sqliteAddTransactionsService;
            _sqliteGetTransactionsService = sqliteGetTransactionsService;

        }

        [HttpPost]
        public async Task<IActionResult> MakeTransaction(string accountId, string stockName, SettlementTimeSeries timeSeries, SettlementInterval interval, int quantity)
        {
            //4d39f99a-e8e8-4fb3-a1f7-7747e9cf9660
            //e563472d-988d-4697-81b8-c5b0e319c1f6

            //var account =   await _accountInfoService.GetAccount(accountId);
            //var stock =   await _stockInfoService.GetStock(stockName, timeSeries, interval, quantity);
            //var stockPrice =  await _getStockPriceService.GetStockPrice(stock.ToString());
            
            //if(_checkAccountCreditsService.CheckBalance(account, stockPrice, quantity))
            //    return BadRequest($"This account: {account.Username} has not enough credits for this purchase!"); 

            //await _sqliteAddTransactionsService.AddTransaction(account, stockPrice, quantity, stockName);
            List<TransactionStorage> TransactionStorage = await _sqliteGetTransactionsService.GetTransactions();

            //timeSeries : INTRADAY
            //stockName: MSFT
            //interval: 60


            return Ok("Transaction Added in the waiting list! At 00: 00 o'clock it will be executed!");
        }
    }
}
