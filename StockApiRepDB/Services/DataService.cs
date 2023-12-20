using StockApiRepDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB.Services
{
    public class DataService:IRepDataService
    {
        public void CreateDatabase(string connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string dbName = builder.InitialCatalog;

            string createDbQuery = $"CREATE DATABASE {dbName}";
            using (SqlConnection connection = new SqlConnection("Server=(Local)\\SQLEXPRESS01;Database=StockApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"))
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
