using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IDataManager _dataManager;

        private readonly IPasswordHasher _passwordHasher;
        public AuthenticationService(IDataManager dataManager, IPasswordHasher passwordHasher)
        {
            _dataManager = dataManager;
            _passwordHasher = passwordHasher;
        }
        public int Register(string username, string password, string email, decimal balance)
        {
            var accounts = _dataManager.SelectData<Account>("Account");
            if (accounts.Any(acc => acc.Username == username))
            {
                return (int)HttpStatusCode.BadRequest;
            }
            var salt = _passwordHasher.GenerateSalt();
            string hashPass = _passwordHasher.HashPassword(password,salt);
            var newAccount = new Account(username, hashPass, email, balance,Convert.ToBase64String(salt));
            _dataManager.InsertData(newAccount);
            return (int)HttpStatusCode.Created;
        }
        public int Login(string email,string password) 
        {
            var accs = _dataManager.SelectData<Account>("Account");
            var currentAcc = accs.FirstOrDefault((acc) => acc.Email==email);
            var salt = Convert.FromBase64String(currentAcc.Salt);
            if (_passwordHasher.VerifyPassword(password, currentAcc.Password,salt))
            {
                return (int)HttpStatusCode.OK;
            }
            return (int)HttpStatusCode.Unauthorized;
        }
    }
}
