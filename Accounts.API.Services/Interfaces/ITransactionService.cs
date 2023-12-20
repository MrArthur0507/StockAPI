using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface ITransactionService
    {
        public int CreateTransaction(TransactionViewModel transaction);

        public List<TransactionViewModel> GetAllTransactionsForUser(string userId);

        public List<TransactionViewModel> GetAllTransactionsByStock(string stockId);

        public ServiceResponse GetExistingPdf(string filePath, string userId);
    }
}
