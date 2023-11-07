using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        public void CreateIfNotExists();
        public void DeleteIfExists();
        //public void Insert(T entity);
        //public void Update(T entity);
    }
}
