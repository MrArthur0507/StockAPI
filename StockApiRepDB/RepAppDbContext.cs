using StockAPI.Database.Interfaces;
using StockApiRepDB.Data;
using StockApiRepDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB
{
    public class RepAppDbContext
    {
        private readonly IRepDataManager _pDataManager;
        public RepAppDbContext(IRepDataManager pDataManager)
        {
            _pDataManager = pDataManager;
        }

        public void Start ()
        {
           _pDataManager.Start();
        }
    }
}
