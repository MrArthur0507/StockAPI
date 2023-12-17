using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AccountService : IAccountsService
    {
        private readonly IAccountAPIService _accountApiService;

        private readonly IBlacklistService _blacklistService;
        public AccountService(IAccountAPIService accountApiService, IBlacklistService blacklistService)
        {
            _accountApiService = accountApiService;
            _blacklistService = blacklistService;
        }

        public async Task<string> GetAll() => await _accountApiService.GetAll();

        public async Task<string> GetById(string id) => await _accountApiService.GetById(id);

        public async Task<int> Register(string username, string password, string email, string balance)
        {
            if (await _blacklistService.IsEmailValid(email))
            {
                return await _accountApiService.Register(username, password, email, balance); 
            }
            return 401;
        }

        public async Task<string> Login(string email, string password) => await _accountApiService.Login(email, password);
    }
}
