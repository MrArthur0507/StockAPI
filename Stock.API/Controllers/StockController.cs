using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Models;
using Stocks.services;

namespace Stocks.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AlphaVantageService _alphaVantageService;

        public StockController(AlphaVantageService alphaVantageService)
        {
            _alphaVantageService = alphaVantageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockData([FromQuery] Stock stock)
        {
            try
            {
                var data = await _alphaVantageService.GetStockData(stock);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }

}
