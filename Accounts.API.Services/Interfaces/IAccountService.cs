using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface IAccountService
    {

        public List<User> GetAllAccount();
        public User GetAccountById(string id);

        public int AddMoney(string userId, string baseCurrency, decimal amount);
        public void Test(string id);

        public List<GetNotificationViewModel> GetAllNotification(string id);
    }
}
