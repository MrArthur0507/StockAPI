using StockApiRepDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepDataService _dataService;
        public UnitOfWork( IRepDataService dataService)
        {
            _dataService = dataService;
        }
        public IEntityRepository<T> GetRepository<T>(string connectionString) where T : class
        {
            return new EntityRepository<T>(connectionString);
        }
        public void CreateDb(string connectionString)
        {
            _dataService.CreateDatabase(connectionString);
        }
    }
}
