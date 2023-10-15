using StockAPI.Database.Interfaces;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace StockAPI.Database.Data
{
    public class DataManager:IDataManager
    {
        private string connectionString;
        private IDataConfiguration _configuration;
        public DataManager(IDataConfiguration config)
        {
            this.connectionString = config.ConnectionString;
            _configuration = config;
        }
        public void Start()
        {
            _configuration.DatabaseService.Start(connectionString);
        }
        public void CreateTable<T>()
        {
            _configuration.TableService.CreateTable<T>(connectionString);
        }
        public void DeleteTable<T>()
        {
            _configuration.TableService.DeleteTable<T>(connectionString);
        }
        public void InsertData<T>(T data) 
        {
            _configuration.TableService.InsertData(data, connectionString);
        }
    }
}
