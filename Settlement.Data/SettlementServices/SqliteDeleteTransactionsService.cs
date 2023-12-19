using Microsoft.Data.Sqlite;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.SettlementContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementServices
{
    public class SqliteDeleteTransactionsService : SqliteService, ISqliteDeleteTransactionsService
    {
        public async Task DeleteAllTransactions()
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {filePath}"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Transactions";
                using (SqliteCommand command = new SqliteCommand(deleteQuery, connection))
                {
                    

                    //command.CommandText = deleteQuery;

                    int rows = command.ExecuteNonQuery();
                }

                connection.Close();
            }

            Console.WriteLine("All transactions successfully deleted from the database.");
        }
    }
}
