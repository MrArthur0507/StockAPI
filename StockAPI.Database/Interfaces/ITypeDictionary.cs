using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface ITypeDictionary
    {
        public Dictionary<Type, string> GetSqlTypes();
    }
}
