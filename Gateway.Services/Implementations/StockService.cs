using Gateway.Domain.Models.ApiRelated.Classes;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IStockAPIService _stockAPIService;
        public StockService(IStockAPIService stockAPIService)
        {
            _stockAPIService = stockAPIService;
        }

        public async Task<string> GetStockData(Stock stock)
        {

            return await _stockAPIService.GetStockData(stock);
        }
    }
}
