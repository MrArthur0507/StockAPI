using Microsoft.AspNetCore.Http.HttpResults;
using Quartz;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.Models.AccountModels;
using Settlement.Infrastructure.Models.SettlementModels;
using Settlement.Infrastructure.SettlementContracts;
using Settlement.Services;
using SettlementServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Settlement.Infrastructure.SettlementServices
{
    public class TransactionStorageExecutionService : ITransactionStorageExecutionService
    {
        private AccountInfoService _accountInfoService;
        private string connectionString = "Server=(Local)\\SQLEXPRESS01;Database=StockApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";

        public TransactionStorageExecutionService(AccountInfoService accountInfoService)
        {
            _accountInfoService = accountInfoService;
        }

        public async Task StoreTransactions(Task<List<TransactionStorage>> transactions)
        {


            List<TransactionStorage> storedTransactions = await transactions;

            foreach (TransactionStorage transaction in storedTransactions)
            {
                var account = await _accountInfoService.GetAccount(transaction.AccountId);

                if (account.Balance - account.Balance * 0.15m <= transaction.Price * transaction.Quantity)
                {
                    Console.WriteLine($"{account.Username}'s {transaction} was terminated due to low credits");
                    continue;
                }

                DateOnly date = new DateOnly(transaction.Date.Year, transaction.Date.Month, transaction.Date.Day);
                ApiStockConnectionService connectionService = new ApiStockConnectionService();
                HttpResponseMessage response = await connectionService._httpClient.
                    PostAsync($"https://localhost:5000/api/Transaction/createTransaction?AccountId={transaction.AccountId}&StockName={transaction.Stock}&Date={date.ToString("yyyy-MM-dd")}&Price={transaction.Price}&Quantity={transaction.Quantity}", new StringContent("", Encoding.UTF8, "application/json"));

                Console.WriteLine("transaction is successful !");


                ApiStockConnectionService secondConnectionService = new ApiStockConnectionService();
                HttpResponseMessage secondResponse = await connectionService._httpClient.
                    PostAsync($"https://localhost:5000/api/Account/addMoney?id={transaction.AccountId}&baseCurrency=bgn&amount={-(transaction.Price * transaction.Quantity + transaction.Price * transaction.Quantity * 0.05m)}", new StringContent("", Encoding.UTF8, "application/json"));

                Console.WriteLine($"Credits have been withdrawn from the account !");

            }

        }
    }
}

