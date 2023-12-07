using Settlement.Infrastructure.Models.SettlementModels;
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
using System.Transactions;

namespace Settlement.Infrastructure.SettlementServices
{
    public class TransactionStorageExecutionService
    {
        public TransactionStorageExecutionService() { }

        public void StoreTransactionsInDatabase(List<Transaction> transactions)
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
                    
                    foreach (Transaction transaction in transactions)
                    {
                        string sqlQuery = "INSERT INTO Transactions (Account, Stock, Date, Price, Quantity, Id) VALUES (@AccountId, @StockName, @Date, @Price, @Quantity, @Id)";
                        command.CommandText = sqlQuery;
                        command.Parameters.AddWithValue("@AccountId", transaction.account.Id);
                        command.Parameters.AddWithValue("@StockName", stockName);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);
                        command.Parameters.AddWithValue("@Price", stockData.Close);
                        command.Parameters.AddWithValue("Quantity", quantity);
                    }
                    
                    
                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
    }
}
