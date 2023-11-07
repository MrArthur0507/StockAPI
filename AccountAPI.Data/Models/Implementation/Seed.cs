using AccountAPI.Data.Models.Interfaces;
using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class Seed:ISeed
    {
        private readonly IDataManager _dataManager;
        private readonly IPasswordHasher _hasher;

        public Seed(IDataManager dataManager,IPasswordHasher hasher)
        { 
            _dataManager = dataManager;
            _hasher = hasher;
        }
        public void SeedWithData()
        {
           // CreateStocks();
           // CreateAccounts();
        }
        private void CreateStocks() 
        {
            List<Stock> stocks = new List<Stock>()
            {
                new Stock("PazardjikOOD",1222,23M),
                new Stock("LevskiOOD",14603,99.2M),
                new Stock("AmazonOOD",444512,85.33M),
                new Stock("AliExpress",12,112.23M),
            };
            foreach (var stock in stocks)
            {
                _dataManager.InsertData(stock);
            }
        }
       /* private void CreateAccounts()
        {
            Console.WriteLine("It enters here");
            List<Account> accounts = new List<Account>()
            { new Account("test1",_hasher.HashPassword("123456",out byte[] salt),"test1@abv.bg",200M),
            new Account("test2",_hasher.HashPassword("A12356",out salt),"test2@abv.bg",200M),
            };
            foreach (var account in accounts)
            {
                Console.WriteLine("it enters in foreach");
                _dataManager.InsertData(account);
            }
        }*/
    }
}
