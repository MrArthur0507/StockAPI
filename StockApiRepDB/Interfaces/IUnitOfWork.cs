using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB.Interfaces
{
    public interface IUnitOfWork
    {
        public IEntityRepository<T> GetRepository<T>(string connectionString) where T : class;

        public void CreateDb(string connectionString);
    }
}
