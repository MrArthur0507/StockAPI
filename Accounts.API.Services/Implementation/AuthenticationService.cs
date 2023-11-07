using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using StockAPI.Database.Interfaces;
using StockAPI.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IDataManager _dataManager;

        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthorizationService _authorizationService;
        public AuthenticationService(IDataManager dataManager, IPasswordHasher passwordHasher, IAuthorizationService authorizationService)
        {
            _dataManager = dataManager;
            _passwordHasher = passwordHasher;
            _authorizationService = authorizationService;
        }
        public int Register(string username, string password, string email, decimal balance)
        {
            var accounts = _dataManager.SelectData<Account>("Accounts");
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
        public User Login(string email,string password) 
        {
            try
            {
                var accs = _dataManager.SelectData<Account>("Accounts");
                var currentAcc = accs.FirstOrDefault((acc) => acc.Email == email);
                var salt = Convert.FromBase64String(currentAcc.Salt);
                if (_passwordHasher.VerifyPassword(password, currentAcc.Password, salt))
                {
                    string token = _authorizationService.GenerateJwtToken(currentAcc.Username);
                    _authorizationService.SaveTokenInSessionStorage(token);
                    return new User(currentAcc.Username, currentAcc.Email, currentAcc.Balance);
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int CheckToken(string token)
        {
            if (_authorizationService.CheckToken(token))
            {
                return (int)HttpStatusCode.OK;
            }
            return (int)HttpStatusCode.BadRequest;
        }
    }
}
