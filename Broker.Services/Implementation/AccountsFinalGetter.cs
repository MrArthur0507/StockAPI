using Broker.Models.DTO;
using Broker.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Services.Implementation
{
    public class AccountsFinalGetter : IAccountsFinalGetter
    {
        private readonly IAccountsGetter _accountsGetter;

        public AccountsFinalGetter(IAccountsGetter accountsGetter) { 
            _accountsGetter= accountsGetter;
        }
        public async Task<List<Account>> GetAccounts()
        {
            string json = await _accountsGetter.GetAllAccountsAsJson();
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            Console.WriteLine(accounts.Count);
            return accounts;
        }
    }
}
