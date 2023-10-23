using AccountAPI.Data.Models.Implementation;
using AccountAPI.Data.Models.Interfaces;
using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models
{
    public class ApplicationDbContext
    {
        private readonly IDataManager _dataManager;
        private readonly ISeed _seed;
        public ApplicationDbContext(IDataManager dataManager,ISeed seed) 
        { 
            _dataManager = dataManager;
            _seed = seed;
        }
        public void Start()
        {
            CreateDb();
            CreateTables();
            _seed.SeedWithData();
        }
        private void CreateDb()
        {
            _dataManager.Start();
        }
        private void CreateTables()
        {
           _dataManager.CreateTable<Stock>();
           _dataManager.CreateTable<Account>();
           _dataManager.CreateTable<Transaction>();
        }
    }
}
