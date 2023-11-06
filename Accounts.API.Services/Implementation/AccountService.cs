using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        private readonly IApiService _apiService;
        public AccountService(IDataManager dataManager, IApiService apiService)
        {
            _dataManager = dataManager;
            _apiService = apiService;
        }

        public List<Account> GetAllAccount()
        {
            return _dataManager.SelectData<Account>("Account");
        }
        public Account GetAccountById(string id) 
        {
            return _dataManager.SelectByID<Account>("Account",id);
        }
        public int AddMoney(string userId, string baseCurrency, decimal amount)
        {
            var apiModel = _apiService.Start();
            var user = _dataManager.SelectByID<Account>("Accounts", userId);
            if (user == null)
            {
                return (int)StatusCodes.Status400BadRequest;
            }
            decimal res = _apiService.CalculateCurrencyAmount(amount, baseCurrency, apiModel.conversion_rates);
            user.Balance += res;
            _dataManager.UpdateData<Account>(user, userId);
            return (int)StatusCodes.Status200OK;
        }
        public void Test(string id)
        {
            var user = _dataManager.SelectByID<Account>("Accounts", id);
            user.Username = "Novo ime";
            _dataManager.UpdateData(user, id);
        }
    }
}
