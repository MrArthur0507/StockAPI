namespace Settlement.API.Controllers.SettlementServices;

using Microsoft.Data.Sqlite;
using Settlement.Infrastructure;
using Settlement.Infrastructure.Models.AccountModels;
using Settlement.Infrastructure.Models.SettlementModels;
using Settlement.Infrastructure.SettlementContracts;
using System;
using System.IO;

public class SqliteService : SqliteFilePath
{

    public SqliteService()
    {

        if (!DatabaseExists())
        {
            CreateDb();
        }
    }
    
    private void CreateDb()
    {
        using (File.Create(filePath))
        {
        }
        TableCreate();
        Console.WriteLine("Creating db;");

    }

    private bool DatabaseExists()
    {
        if (File.Exists(filePath))
        {
            return true;
        }
        Console.WriteLine("Db dont exist");
        return false;
    }

    private void TableCreate()
    {
        using(SqliteConnection connection = new SqliteConnection($"Data Source = {filePath}")) 
        {


            connection.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Transactions (
                    TransactionId INTEGER PRIMARY KEY AUTOINCREMENT,
                    AccountId TEXT NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Price REAL NOT NULL,
                    Stock TEXT NOT NULL,
                    TransactionDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                )";
            using(SqliteCommand command = connection.CreateCommand()) 
            {
                command.CommandText = createTableQuery;
                command.ExecuteNonQuery();
            }
        }
    }
}
