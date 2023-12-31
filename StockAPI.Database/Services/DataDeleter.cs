﻿using StockAPI.Database.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Services
{
    public class DataDeleter:IDataDeleter
    {
        public void InsertData<T>(T data, string connectionString)
        {
            string tableName = typeof(T).Name;
            var properties = typeof(T).GetProperties().Where(prop => prop.CanRead && prop.PropertyType.BaseType.Name != "BaseModel");
            string columnNames = string.Join(", ", properties.Select(prop => prop.Name));
            string values = string.Join(", ", properties.Select(prop => $"@{prop.Name}"));
            columnNames += ", IsDeleted";
            values += ", @IsDeleted";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"INSERT INTO {tableName}s ({columnNames}) VALUES ({values})";
                SqlCommand command = new SqlCommand(query, connection);

                foreach (var property in properties)
                {
                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>) &&
                        property.PropertyType.GetGenericArguments()[0].IsSubclassOf(typeof(object)))
                    {
                        var itemList = property.GetValue(data) as IList;
                        foreach (var item in itemList)
                        {
                            InsertData(item, connectionString);
                        }
                    }
                    else
                    {
                        
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(data));
                    }
                }
                command.Parameters.AddWithValue("@IsDeleted", 0);

                command.ExecuteNonQuery();
            }
        }
    }
}
