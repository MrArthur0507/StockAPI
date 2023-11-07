using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB.Interfaces
{
    public interface IRepDataService
    {

        public void CreateDatabase(string connectionString);
    }
}
