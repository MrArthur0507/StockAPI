namespace Settlement.API.Controllers.SettlementServices;

using AccountAPI.Data.Models.ApiModels;
using AccountAPI.Data.Models.Implementation;
using Microsoft.Data.Sqlite;
using Settlement.API.Controllers.Data.Models;
using System;
using System.Data.SQLite;
using System.IO;

public class SqliteService
{

    public SqliteService()
    {

        if (!DatabaseExists())
        {
            CreateDb();
        }
    }

    private string filePath = "SettlementTransactions.db";

    
    public async Task AddTransaction(AccountAPI.Data.Models.Implementation.Account account,  double price, int quantity, string stockName)
    {
        using (SqliteConnection connection = new SqliteConnection($"Data Source = {filePath}"))
        {
            connection.Open();
            using(SqliteCommand command = connection.CreateCommand())
            {
                string insertQuery = @"
                INSERT INTO Transactions (AccountId, Quantity, Price, Stock)
                VALUES (@AccountId, @Quantity, @Price, @StockId)";

               

                    command.Parameters.AddWithValue("@AccountId", account.Id);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@StockId", stockName);


                    command.ExecuteNonQuery();
                

                connection.Close();
            }

        }
        Console.WriteLine("values successfully added to transactions");

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
                    AccountId INTEGER NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Price DECIMAL(10, 2) NOT NULL,
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









    //private string connectionString;

    //public SqliteService(string dbFilePath)
    //{
    //    // Set your SQLite connection string
    //    connectionString = $"Data Source={dbFilePath};Version=3;";
    //}

    //public void ExportDataToTextFile(string textFilePath)
    //{

    //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    //    {
    //        connection.Open();

    //        using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM YourTableName", connection))
    //        {
    //            using (SQLiteDataReader reader = command.ExecuteReader())
    //            {
    //                // Create or overwrite the text file
    //                using (StreamWriter writer = new StreamWriter(textFilePath))
    //                {
    //                    // Write column headers
    //                    for (int i = 0; i < reader.FieldCount; i++)
    //                    {
    //                        writer.Write(reader.GetName(i));
    //                        if (i < reader.FieldCount - 1)
    //                            writer.Write(",");
    //                    }
    //                    writer.WriteLine();

    //                    // Write data
    //                    while (reader.Read())
    //                    {
    //                        for (int i = 0; i < reader.FieldCount; i++)
    //                        {
    //                            writer.Write(reader[i]);
    //                            if (i < reader.FieldCount - 1)
    //                                writer.Write(",");
    //                        }
    //                        writer.WriteLine();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
