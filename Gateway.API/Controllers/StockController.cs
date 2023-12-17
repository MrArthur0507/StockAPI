using Gateway.Services.Implementations;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Gateway.API.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService) { 
            _stockService= stockService;
        }

        [HttpGet]
        [Route("getStockData")]

        
        public async Task<string> GetStockData()
        {
            //var stockResponse = await _stockService.GetStockData(stock);

            return "Ok";
        }
    }
}
