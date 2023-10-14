using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface IDatabaseService
    {
        public void Start(string connectionString);
    }
}
