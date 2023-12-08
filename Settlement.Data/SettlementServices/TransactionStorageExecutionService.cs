using Settlement.Infrastructure.Models.AccountModels;
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
                        command.Parameters.AddWithValue("@AccountId", transaction.Account);
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
