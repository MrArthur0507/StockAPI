using StockAPI.Database.Data;
using StockAPI.Database.Helpers;
using StockAPI.Database.Interfaces;
using System.Data.SqlClient;
using System.Transactions;

namespace StockAPI.Database.Services
{
    public class TableService:ITableService
    {

        private ITypeDictionary _dictionary;
        private IDataInserter _inserter;
        public TableService(ITypeDictionary dictionary,IDataInserter inserter) 
        {
            _dictionary = dictionary;
            _inserter = inserter;
        }
        public void CreateTable<T>(string connectionString)
        {
            try
            {
                string tableName = typeof(T).Name;
                var columns = GetColumnsFromType<T>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"CREATE TABLE {tableName}s (Id NVARCHAR(255) PRIMARY KEY, {string.Join(", ", columns)})";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    if (typeof(T).BaseType.Name == "BaseModel")
                    {
                        AddForeignKeys(connection);
                    }
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void DeleteTable<T>(string connectionString)
        {
            string tableName = typeof(T).Name;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"DROP TABLE {tableName}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        public void InsertData<T>(T data,string connectionString)
        {
            _inserter.InsertData(data,connectionString);
        }
        private string[] GetColumnsFromType<T>()
        {
            var properties = typeof(T).GetProperties().Where(prop => prop.Name != "Id" && prop.PropertyType.BaseType.Name!="BaseModel");
            return properties.Select(property =>
            {
                string columnName = property.Name;
                string columnType = GetSqlTypeFromCSharpType(property.PropertyType);
                return $"{columnName} {columnType}";
            }).ToArray();
        }
        public void UpdateData<T>(T data, string connectionString, string primaryKey)
        {
            _inserter.UpdateData(data, connectionString, primaryKey);
        }
        private string GetSqlTypeFromCSharpType(Type type)
        {
            var dictionary = _dictionary.GetSqlTypes();
            if (Checking(type))
            {
                return "NVARCHAR(255)";
            }
            if (dictionary.ContainsKey(type))
            {
                return dictionary[type];
            }
            throw new NotSupportedException($"Type {type} is not supported for SQL columns.");
        }
        private void AddForeignKeys(SqlConnection connection)
        {
            // AddForeignKeyConstraint("Accounts", "Id", "Transactions", "Account", connection);
            // AddForeignKeyConstraint("Stocks", "Id", "Transactions", "Stock", connection);
            // AddForeignKeyConstraint("Accounts", "Id", "Notifications", "Account", connection);
            try
            {
                AddForeignKeyConstraint("Accounts", "Id", "Transactions", "Account", connection);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {

                AddForeignKeyConstraint("Stocks", "Id", "Transactions", "Stock", connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {

                AddForeignKeyConstraint("Accounts", "Id", "Notifications", "Account", connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool Checking(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) ||  type.BaseType.Name=="BaseModel")
            {
                return true;
            }
            else if (typeof(ICollection<>).IsAssignableFrom(type))
            {
                return true;
            }
            return false;
        }
        private void AddForeignKeyConstraint(string parentTable, string parentColumn, string childTable, string childColumn, SqlConnection connection)
        {
            string foreignKeyQuery = $"ALTER TABLE {childTable} " +
                                     $"ADD CONSTRAINT FK_{childTable}_{parentTable} " +
                                     $"FOREIGN KEY ({childColumn}) REFERENCES {parentTable}({parentColumn})";
            SqlCommand foreignKeyCommand = new SqlCommand(foreignKeyQuery, connection);
            foreignKeyCommand.ExecuteNonQuery();
        }
    }
}
