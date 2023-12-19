using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
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

        public List<User> GetAllAccount()
        {
            var accounts = _dataManager.SelectData<Account>("Accounts");
            List<User> result = new List<User>();
            foreach (var account in accounts)
            {
                result.Add(new User(account.Username, account.Email, account.Balance));
            }

            return result;
        }
        public User GetAccountById(string id) 
        {
            var account = _dataManager.SelectByID<Account>("Accounts", id);

            return new User(account.Username,account.Email,account.Balance);
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
        public List<GetNotificationViewModel> GetAllNotification(string id)
        {
            var result = _dataManager.SelectData<Notification>("Notifications").Where(n=>n.AccountId==id).Select(n=> new GetNotificationViewModel
            {
                Message=n.Message,
            }).ToList();
            return result;
        }
    }
}
