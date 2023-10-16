using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface IDataManager
    {
        public void Start();
        public void CreateTable<T>();
        public void DeleteTable<T>();
        public void InsertData<T>(T data);
        public List<T> SelectData<T>(string table);
        public T SelectByID<T>(string table, string id);
    }
}
