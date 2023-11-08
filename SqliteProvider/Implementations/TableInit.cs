using Microsoft.Data.Sqlite;
using SqliteProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Implementations
{
    public class TableInit : ITableInit
    {
        public void CreateTables(string connectionString)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source = {connectionString}"))
            {
                connection.Open();
                string query = "CREATE TABLE IF NOT EXISTS Requests (Id INTEGER PRIMARY KEY AUTOINCREMENT, VisitorIp TEXT, RequestTime DATETIME)";
                 using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
