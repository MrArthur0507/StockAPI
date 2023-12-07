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
using Settlement.Infrastructure.SettlementServices;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly AccountInfoService _accountInfoService;
        private readonly StockInfoService _stockInfoService;
        private readonly GetStockPriceService _getStockPriceService;
        private readonly SqliteService _sqliteService;

        public TransactionsController(AccountInfoService accountInfoService,
            StockInfoService stockInfoService, GetStockPriceService getStockPriceService, SqliteService sqliteService)
        {

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
            await _sqliteService.AddTransaction(await account, await stockPrice, quantity, stockName);

            //timeSeries : INTRADAY
            //stockName: MSFT
            //interval: 60


            return Ok(stock);
        }
    }
}
