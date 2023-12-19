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
        [HttpGet("/get-existing-pdf")]
        public IActionResult GetExistingPdf()
        {
            string filePath = "D:\\VTU software engineering\\C#\\StockAPI\\Accounts.API\\transactions\\20231124_b18ce351-e9fd-467d-8511-b088acc7f81b_TransactionDetails.pdf";

            // Call the service method
            var serviceResponse = _transactionService.GetExistingPdf(filePath);

            if (serviceResponse.IsSuccess)
            {
                return new FileContentResult(serviceResponse.PdfContent, "application/pdf")
                {
                    FileDownloadName = serviceResponse.FileName
                };
            }
            else
            {
                Console.WriteLine($"Error: {serviceResponse.ErrorMessage}");
                return BadRequest(); // or return a custom error response
            }
        }
    }
}
