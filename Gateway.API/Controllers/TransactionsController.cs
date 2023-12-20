using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService) { 
            _transactionService = transactionService;
        }


        [HttpGet]
        [Route("getTransactionForUser")]
        public async Task<string> GetTransactionForUser(string id)
        {
            return await _transactionService.GetTransactionForUser(id);
        }

        [HttpGet]
        [Route("getTransactionByStock")]
        public async Task<string> GetTransactionByStock(string stockiId)
        {
            return await _transactionService.GetTransactionByStock(stockiId);
        }
    }
}
