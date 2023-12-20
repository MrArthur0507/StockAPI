using Microsoft.Data.Sqlite;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.Models.AccountModels;
using Settlement.Infrastructure.SettlementContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementServices
{
    public class SqliteAddTransactionsService : SqliteService, ISqliteAddTransactionsService
    {
        public async Task AddTransaction(Account account, double price, int quantity, string stockName)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source={filePath}"))
            {
                connection.Open();
                string insertQuery = @"
                INSERT INTO Transactions (AccountId, Quantity, Price, Stock, TransactionDate)
                VALUES (@AccountId, @Quantity, @Price, @Stock, @TransactionDate)";

                using (SqliteCommand command = new SqliteCommand(insertQuery, connection))
                {



                    command.Parameters.AddWithValue("@AccountId", account.Id);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Stock", stockName);
                    command.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString());


                    int rows = command.ExecuteNonQuery();

                    //int rowsAffected = command.ExecuteNonQuery();
                }

                connection.Close();

            }
        }
    }
}
