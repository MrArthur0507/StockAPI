using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionAPIService _transactionAPIService;

        public TransactionService(ITransactionAPIService transactionAPIService) {
            _transactionAPIService = transactionAPIService;
        }

        public async Task<string> GetTransactionForUser(string id) => await _transactionAPIService.GetTransactionForUser(id);

        public async Task<string> GetTransactionByStock(string stockId) => await _transactionAPIService.GetTransactionByStock(stockId);
    }
}
