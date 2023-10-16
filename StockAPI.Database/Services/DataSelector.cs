using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Services
{
    public class DataSelector : IDataSelector
    {
        public T SelectByID<T>(string table, string id, string connectionString)
        {
            string query = $"SELECT * FROM {table} WHERE Id = @Id";
            T item = default(T);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    item = CreateInstance<T>(reader);

                    foreach (var property in typeof(T).GetProperties())
                    {
                        SetValueIfNotNull(item, property, reader[property.Name]);
                    }
                }

                reader.Close();
            }

            return item;
        }
        private T CreateInstance<T>(SqlDataReader reader)
        {
            var constructor = typeof(T).GetConstructor(Type.EmptyTypes);

            if (constructor == null)
            {
                throw new InvalidOperationException($"No parameterless constructor defined for type {typeof(T)}.");
            }

            var parameters = GetParametersFromReader<T>(reader, constructor.GetParameters());
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }

        private object[] GetParametersFromReader<T>(SqlDataReader reader, ParameterInfo[] parameters)
        {
            return parameters.Select(parameter =>
            {
                var columnName = parameter.Name;
                var value = reader[columnName];
                return Convert.ChangeType(value, parameter.ParameterType);
            }).ToArray();
        }

        private void SetValueIfNotNull<T>(T item, PropertyInfo property, object value)
        {
            if (property.GetSetMethod() != null && value != DBNull.Value)
            {
                property.SetValue(item, Convert.ChangeType(value, property.PropertyType));
            }
        }

        public List<T> SelectData<T>(string table,string connectionString)
        {
            List<T> results = new List<T>();
            string query = $"SELECT * FROM {table}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T item = Activator.CreateInstance<T>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var propertyName = reader.GetName(i);
                        var property = typeof(T).GetProperty(propertyName);

                        // Check if the property exists
                        if (property != null && !reader.IsDBNull(i))
                        {
                            var value = reader.GetValue(i);
                            property.SetValue(item, value);
                        }
                    }

                    results.Add(item);
                }

                reader.Close();
            }

            return results;
        }
    }
}
