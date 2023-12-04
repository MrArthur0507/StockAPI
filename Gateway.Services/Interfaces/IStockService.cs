using Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IStockService
    {
        public Task<string> GetStockData(Stock stock);
    }
}
