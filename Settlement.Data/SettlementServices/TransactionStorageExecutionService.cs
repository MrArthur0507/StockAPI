using Microsoft.AspNetCore.Http.HttpResults;
using Quartz;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.Models.AccountModels;
using Settlement.Infrastructure.Models.SettlementModels;
using Settlement.Infrastructure.SettlementContracts;
using Settlement.Infrastructure.SettlementContracts.StockContracts;
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

        public TransactionStorageExecutionService(AccountInfoService accountInfoService)
        {
            _accountInfoService = accountInfoService;
        }

        public async Task StoreTransactions(Task<List<TransactionStorage>> transactions)
        {
            string connectionString = "Server=(Local)\\SQLEXPRESS01;Database=StockApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL operations will go here.


                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    // Define your SQL query
                    List<TransactionStorage> storedTransactions = await transactions;

                    foreach (TransactionStorage transaction in storedTransactions)
                    {
                        var account = await _accountInfoService.GetAccount(transaction.AccountId);
                        if (account.Balance * 0.15m < transaction.Price * transaction.Quantity)
                        {
                            Console.WriteLine($"{account.Username}'s {transaction} was terminated due to low credits");
                            continue;
                        }

                        string sqlQuery = "INSERT INTO Transactions (Account, Stock, Date, Price, Quantity, Id) VALUES (@AccountId, @StockName, @Date, @Price, @Quantity, @Id);" +
                            "UPDATE Accounts SET Balance = Balance - (@Amount + @Amount * 0.05) WHERE Id = @AccountId;";
                        command.CommandText = sqlQuery;
                        command.Parameters.AddWithValue("@AccountId", transaction.AccountId);
                        command.Parameters.AddWithValue("@StockName", transaction.Stock);
                        command.Parameters.AddWithValue("@Date", transaction.Date);
                        command.Parameters.AddWithValue("@Price", transaction.Price);
                        command.Parameters.AddWithValue("Quantity", transaction.Quantity);


                    }


                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
    }
}
