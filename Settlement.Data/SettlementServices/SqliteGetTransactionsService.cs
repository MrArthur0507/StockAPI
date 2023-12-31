﻿using Microsoft.Data.Sqlite;
using Microsoft.SqlServer.Server;
using Settlement.API.Controllers.SettlementServices;
using Settlement.Infrastructure.Models.SettlementModels;
using Settlement.Infrastructure.SettlementContracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementServices
{
    public class SqliteGetTransactionsService : SqliteService, ISqliteGetTransactionsService
    {
        public async Task<List<TransactionStorage>> GetTransactions()
        {
            List<TransactionStorage> transactions = new List<TransactionStorage>();
            using (SqliteConnection connection = new SqliteConnection($"Data Source={filePath}"))
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
                                DateTime transactionDate =Convert.ToDateTime(reader.GetString
                                    (reader.GetOrdinal("TransactionDate"))
                                    .ToString(CultureInfo.CurrentCulture));


                                

                                //DateTime.TryParseExact(reader.GetDateTime(reader.GetOrdinal("TransactionDate")), "dd.MM.yyyy г. HH:mm:ss",
                                //    cultureInfo, DateTimeStyles.None, out DateTime resultDateTime);


                                    TransactionStorage transaction = new TransactionStorage();
                                //transaction.Id = transactionId;
                                transaction.AccountId = accountId;
                                transaction.Stock = stockName;
                                transaction.Quantity = quantity;
                                transaction.Price = price;
                                transaction.Date = transactionDate;
                                transactions.Add(transaction);
                            }
                        }
                    }
                }

                return transactions;
            }
        }
    }
}
