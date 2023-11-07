using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface ITableService
    {
        public void CreateTable<T>(string connectionString);
        public void DeleteTable<T>(string connectionString);
        public void InsertData<T>(T data, string connectionString);
        public void UpdateData<T>(T data, string connectionString, string primaryKey);
    }
}
