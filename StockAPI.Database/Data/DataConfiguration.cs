using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Data
{
    public class DataConfiguration:IDataConfiguration
    {

        public IDatabaseService DatabaseService { get; set; }
        public ITableService TableService { get; set; }

        public IDataSelector DataSelector { get; set; }

        public string ConnectionString => "Server=DESKTOP-4UNOHKM\\SQLEXPRESS;Initial Catalog=StockTesting1;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;";




        public DataConfiguration(IDatabaseService dbService, ITableService tbService, IDataSelector dataSelector)
        {
            DatabaseService = dbService;
            TableService = tbService;
            DataSelector = dataSelector;
        }
    }
}
