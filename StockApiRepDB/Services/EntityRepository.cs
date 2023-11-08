using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StockApiRepDB.Interfaces;

namespace StockApiRepDB.Services
{
    public class EntityRepository<T>:IEntityRepository<T> where T : class
    {
        private readonly string _connectionString;
        public EntityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void CreateIfNotExists()
        {

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var tableName = typeof(T).Name;
                    var command = new SqlCommand($"CREATE TABLE {tableName}s ({GetColumns()})", connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteIfExists()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tableName = typeof(T).Name;
                var command = new SqlCommand($"DROP TABLE {tableName}s", connection);
                command.ExecuteNonQuery();
            }
        }
        private string GetColumns()
        {
            var properties = typeof(T).GetProperties();
            var columns = new List<string>();
            foreach (var property in properties)
            {
                var type = GetSqlType(property.PropertyType);
                var columnName = property.Name;
                if (property.PropertyType.BaseType?.Name == "BaseModel")
                {
                    var parentTable = property.PropertyType.Name;
                    var parentColumn = "Id";
                    columns.Add($"{columnName} nvarchar(256) FOREIGN KEY REFERENCES {parentTable}s({parentColumn})");
                }
                else if(columnName=="Id")
                {
                    columns.Add($"{columnName} NVARCHAR(256) PRIMARY KEY");
                }
                else
                {
                    columns.Add($"{columnName} {type}");
                }
            }
            return string.Join(", ", columns);
        }
        private string GetSqlType(Type type)
        {
            if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(string))
            {
                return "nvarchar(MAX)";
            }
            else if (type == typeof(DateTime))
            {
                return "datetime";
            }
            else if (type == typeof(decimal))
            {
                return "DECIMAL(18,2)";
            }
            else if (type.BaseType.Name == "BaseModel")
            {
                return "nvarchar(MAX)";
            }
            else
            {
                throw new NotSupportedException($"The type {type} is not supported.");
            }
        }
    }
}
