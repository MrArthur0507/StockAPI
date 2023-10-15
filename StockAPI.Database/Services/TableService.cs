using StockAPI.Database.Data;
using StockAPI.Database.Interfaces;
using System.Data.SqlClient;

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
            string tableName = typeof(T).Name;
            var columns = GetColumnsFromType<T>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"CREATE TABLE {tableName} ({string.Join(", ", columns)})";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
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
            _inserter.InsertData<T>(data,connectionString);
        }
        private string[] GetColumnsFromType<T>()
        {
            var properties = typeof(T).GetProperties();
            return properties.Select(property =>
            {
                string columnName = property.Name;
                string columnType = GetSqlTypeFromCSharpType(property.PropertyType);
                return $"{columnName} {columnType}";
            }).ToArray();
        }

        private string GetSqlTypeFromCSharpType(Type type)
        {
            var dictionary = _dictionary.GetSqlTypes();

            if (dictionary.ContainsKey(type))
            {
                return dictionary[type];
            }
            throw new NotSupportedException($"Type {type} is not supported for SQL columns.");
        }
    }
}
