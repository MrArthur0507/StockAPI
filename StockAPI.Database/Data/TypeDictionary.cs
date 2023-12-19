using StockAPI.Database.Helpers;
using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Data
{
    public class TypeDictionary:ITypeDictionary
    {
        private Dictionary<Type, string> _typeMap { get; } = new Dictionary<Type, string>() {
            { typeof(Guid), "UNIQUEIDENTIFIER" },
            { typeof(string), "NVARCHAR(255)" },
            { typeof(int), "INT" },
            { typeof(decimal), "DECIMAL(18,2)" },
            { typeof(DateTime), "DATETIME" },
            {typeof(DummyModel),"NVARCHAR(255)" },
            {typeof(bool),"BIT" }   
        };
        public Dictionary<Type, string> GetSqlTypes()
        {
            return _typeMap;
        }
    }
}
