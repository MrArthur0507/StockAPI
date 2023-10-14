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
        public string ConnectionString => "Server=DESKTOP-JAGL7D3\\SQLEXPRESS;Database=Stockss;Integrated Security=true;";

        public DataConfiguration(IDatabaseService dbService, ITableService tbService)
        {
            this.DatabaseService = dbService;
            this.TableService = tbService;
        }
    }
}
