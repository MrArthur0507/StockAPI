using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementServices;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApiAccountService _apiAccountService;
        private readonly ApiStockService _apiStockService;

        public TransactionsController(ApiAccountService apiAccountService, ApiStockService apiStockService)
        {
            _apiAccountService = apiAccountService;
            _apiStockService = apiStockService;
        }


        [HttpPatch]
        public async Task<IActionResult> Transaction(string accountId, string stockName)
        {
            try
            {
                await _apiAccountService.GetAccountByIdAsync(accountId);
                await _apiStockService.GetStockByName(stockName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return BadRequest("Not enough credit to buy the stock!");


            


        }
    }
}
