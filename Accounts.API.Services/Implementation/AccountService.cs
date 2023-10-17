using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using StockAPI.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class AccountService:IAccountService
    {
        private readonly IDataManager _dataManager;
        public AccountService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<Account> GetAllAccount()
        {
            return _dataManager.SelectData<Account>("Account");
        }
        public Account GetAccountById(string id) 
        {
            return _dataManager.SelectByID<Account>("Account",id);
        }
    }
}
