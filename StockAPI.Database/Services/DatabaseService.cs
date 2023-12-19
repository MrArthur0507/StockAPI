using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Services
{
    public class DatabaseService:IDatabaseService
    {
        private readonly ITableService _service;
        public DatabaseService(ITableService service)
        {
            _service = service;
        }

        public void Start(string connectionString)
        {
            CreateDatabase(connectionString);
            _service.AddForeignKeys(connectionString);

        }
      /*  private void CreateDatabase(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"USE master;CREATE DATABASE {connection.Database}";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/
      private void CreateDatabase(string connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string dbName = builder.InitialCatalog;

            string createDbQuery = $"CREATE DATABASE {dbName}";
            using (SqlConnection connection = new SqlConnection($"Data Source={builder.DataSource};Initial Catalog=master;Integrated Security=True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(createDbQuery, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Database {dbName} created successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
