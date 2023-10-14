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

    }
}
