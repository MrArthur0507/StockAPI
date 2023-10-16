using StockAPI.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface IDataConfiguration
    {
        public IDatabaseService DatabaseService { get; }
        public ITableService TableService { get; }
        public IDataSelector DataSelector { get; }
        string ConnectionString { get; }
    }
}
