using AccountAPI.Data.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface IAccountService
    {

        public List<Account> GetAllAccount();
        public Account GetAccountById(string id);
    }
}
