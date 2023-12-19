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
        private readonly IStockLogger _stockLogger;

        public AuthenticationService(IDataManager dataManager, IPasswordHasher passwordHasher, IAuthorizationService authorizationService, IStockLogger stockLogger)
        {
            _dataManager = dataManager;
            _passwordHasher = passwordHasher;
            _authorizationService = authorizationService;
            _stockLogger = stockLogger;
        }
        public int Register(string username, string password, string email)
        {
            var accounts = _dataManager.SelectData<Account>("Accounts");
            if (accounts.Any(acc => acc.Username == username))
            {
                return (int)HttpStatusCode.BadRequest;
            }
            var salt = _passwordHasher.GenerateSalt();
            string hashPass = _passwordHasher.HashPassword(password,salt);
            var newAccount = new Account(username, hashPass, email,Convert.ToBase64String(salt));
            _dataManager.InsertData(newAccount);
            User user = new User(newAccount.Username, newAccount.Email, newAccount.Balance);
            _stockLogger.SaveRegInFile(user);
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
                    User user = new User(currentAcc.Username, currentAcc.Email, currentAcc.Balance);
                    _stockLogger.SaveLoginInFile(user);
                    return user;
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
