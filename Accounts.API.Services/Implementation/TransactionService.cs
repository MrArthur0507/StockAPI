using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class TransactionService:ITransactionService
    {

        private readonly IDataManager _dataManager;
        public TransactionService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public int CreateTransaction(TransactionViewModel transaction)
        {
            var transactions = _dataManager.SelectData<Transaction>("Transactions");
            var user = _dataManager.SelectData<Account>("Accounts").SingleOrDefault((acc)=>acc.Id==transaction.AccountId);
            if (transaction == null || user ==null || transactions.Any(acc => acc.StockName == transaction.StockName && acc.AccountId == transaction.AccountId))
            {
                return StatusCodes.Status400BadRequest;
            }
            var transactionDb = new Transaction(transaction.AccountId, transaction.StockName, transaction.Date, transaction.Price, transaction.Quantity);
            try
            {
                _dataManager.InsertData(transactionDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCodes.Status400BadRequest;
            }
            return StatusCodes.Status201Created;
        }
        public List<TransactionViewModel> GetAllTransactionsForUser(string userId) 
        {
            var transactions = _dataManager.SelectData<Transaction>("Transactions").Where((transaction)=>transaction.AccountId==userId);
            List<TransactionViewModel> result = new List<TransactionViewModel>();
            if (transactions!=null)
            {
                foreach (var transaction in transactions)
                {
                    result.Add(new TransactionViewModel(transaction.AccountId,transaction.StockName,transaction.Date,transaction.Price,transaction.Quantity));
                }
            }
            return result;
        }
        public List<TransactionViewModel> GetAllTransactionsByStock(string stockId)
        {
            var transactions = _dataManager.SelectData<Transaction>("Transactions").Where((transaction) => transaction.StockName == stockId);
            List<TransactionViewModel> result = new List<TransactionViewModel>();
            if (transactions != null)
            {
                foreach (var transaction in transactions)
                {
                    result.Add(new TransactionViewModel(transaction.AccountId, transaction.StockName, transaction.Date, transaction.Price, transaction.Quantity));
                }
            }
            return result;
        }
    }
}
