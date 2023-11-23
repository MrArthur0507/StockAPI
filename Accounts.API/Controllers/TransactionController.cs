using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers
{

    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("createTransaction")]
        public IActionResult CreateTransaciton(TransactionViewModel transaction)
        {
            return StatusCode(_transactionService.CreateTransaction(transaction));
        }
        [HttpGet]
        [Route("getTransactionForUser")]
        public IActionResult GetTransactionForUser(string userId)
        {
            return Json(_transactionService.GetAllTransactionsForUser(userId));
        }
        [HttpGet]
        [Route("getTransactionByStock")]
        public IActionResult GetTransactionByName(string stockId)
        {
            return Json(_transactionService.GetAllTransactionsByStock(stockId));
        }
    }
}
