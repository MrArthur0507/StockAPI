using Microsoft.Data.Sqlite;
using SqliteProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "CREATE TABLE IF NOT EXISTS Requests (Id INTEGER PRIMARY KEY AUTOINCREMENT, VisitorIp TEXT, RequestTime DATETIME);" +
                                        "CREATE TABLE IF NOT EXISTS Emails (Id INTEGER PRIMARY KEY AUTOINCREMENT, Email TEXT, IsValid INTEGER);" +
                                        "CREATE TABLE IF NOT EXISTS DetailedRequests(Id INTEGER PRIMARY KEY AUTOINCREMENT, HttpMethod TEXT, Timestamp DATETIME);";
                                   
                        using (SqliteCommand command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        
                        transaction.Rollback();
                        Console.WriteLine($"Transaction rolled back. Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
