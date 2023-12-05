using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Settlement.API.Controllers.SettlementServices.Models;
using SettlementServices;
using Stocks.Enums;
using System.Security.Cryptography.X509Certificates;
using StockAPI.Database.Interfaces;
using Stocks.utils;

namespace Settlement.API.Controllers.SettlementServices
{
    public class AccountInfoService
    {
        private readonly ApiAccountService _apiAccountService;

        public AccountInfoService(ApiAccountService apiAccountService)
        {
            _apiAccountService = apiAccountService;
        }


        public async Task<Data.Models.Account> GetAccount(string accountId)
        {
            var account = await _apiAccountService.GetAccountByIdAsync(accountId);
            return account;
        }

        

        

        
        
    }
}
