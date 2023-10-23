using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Settlement.API.Services;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionsController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Transaction(int senderId, int recieverId, decimal stockTotalPrice, int quantity)
        {
            return BadRequest("Transaction failed");
        }
    }
}
