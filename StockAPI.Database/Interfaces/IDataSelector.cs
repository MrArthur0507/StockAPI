using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface IDataSelector
    {
        public List<T> SelectData<T>(string table, string connectionString);
        public T SelectByID<T>(string table,string id, string connectionString);
    }
}
