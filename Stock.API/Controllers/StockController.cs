//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Interfaces;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using Stocks.Models;
using Stocks.services;
using Stocks.utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Stocks.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AlphaVantageService _alphaVantageService;
        private readonly DbService _dbService;
        private readonly ILogger<StockController> _logger;

        public StockController(AlphaVantageService alphaVantageService, DbService dbService, ILogger<StockController> logger)
        //

        {
            _alphaVantageService = alphaVantageService;
            _dbService = dbService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockData([FromQuery] Stock stock)
        {
            // first pass the stock to the IsStockIsPresentInDb method
            // there we check if there is such a stock in the db
            // if so , get the data from there , and if not
            // proceed with the API call and add the data to the db




            var stockDataFromDb = await _dbService.GetDataFromDb(stock);

            if (stockDataFromDb == null)
            {
                try
                {
                    var data = await _alphaVantageService.GetStockData(stock);
                    await _dbService.AddToDb(data);
                    return Ok(data);
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error calling AlphaVantage API: {ex.Message}");
                }
                catch (Exception ex)
                {
                    return BadRequest($"An unexpected error occurred: {ex.Message}");
                }
            }
            else
            {
                _logger.LogCritical("This data is from the DB ");
                return Ok(stockDataFromDb);
            }


        }
    }

}
