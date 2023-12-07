namespace Settlement.API.Controllers.SettlementServices;

using Microsoft.Data.Sqlite;
using Settlement.Infrastructure.Models.AccountModels;
using System;
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


    public async Task GetTransactions()
    {
        List<Transaction> transactions =  new List<Transaction>();
        using (SqliteConnection connection = new SqliteConnection(filePath)) 
        {
            connection.Open();

            string tableName = "Transactions";

            string query = $"SELECT * FROM {tableName}";

            using (SqliteCommand command = new SqliteCommand(query, connection)) 
            {

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    // Check if the reader has any rows
                    if (reader.HasRows)
                    {
                        // Process each row
                        while (reader.Read())
                        {
                            // Access values by column index or name
                            string transactionId = reader.GetString(reader.GetOrdinal("TransactionId"));
                            string accountId = reader.GetString(reader.GetOrdinal("AccountId"));
                            string stockName = reader.GetString(reader.GetOrdinal("Stock"));
                            int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            DateTime transactionDate = reader.GetDateTime(reader.GetOrdinal("TransactionDate"));

                            Transaction transaction = new Transaction();
                            transaction.Id = transactionId;
                            transaction.Account = accountId;
                            transaction.Stock = stockName;
                            transaction.Quantity = quantity;
                            transaction.Price = price;
                            transaction.Date = transactionDate;
                            transactions.Add(transaction);
                        }
                    }
                }
            }
        }
    }

    
    public async Task AddTransaction(Account account,  double price, int quantity, string stockName)
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
}
