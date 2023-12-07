using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Settlement.Infrastructure.Models;
using Settlement.Infrastructure.SettlementServices;
using Stocks.Enums;
using System.Security.Cryptography.X509Certificates;
using Stocks.utils;
using Settlement.Infrastructure.Models;
using System.Threading.Tasks;


namespace SettlementServices
{
    public class AccountInfoService
    {
        private readonly ApiAccountService _apiAccountService;

        public AccountInfoService(ApiAccountService apiAccountService)
        {
            _apiAccountService = apiAccountService;
        }


        public async Task<Account> GetAccount(string accountId)
        {
            var account = await _apiAccountService.GetAccountByIdAsync(accountId);
            return account;
        }

        

        

        
        
    }
}
