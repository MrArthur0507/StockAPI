﻿using Gateway.Services.Configuration.Interfaces;
using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AccountAPIService : BaseAPIService, IAccountAPIService
    {
        public AccountAPIService(IConfigurationService configurationService, IHttpClientFactory clientFactory)
            : base(clientFactory, configurationService)
        {
            client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(config.AccountConfig.Host);
        }

        public async Task<string> GetAll()
        {
            HttpResponseMessage response = await GetAsync(client.BaseAddress + config.AccountConfig.GetAll);
            return await HandleResponse(response);
        }

        public async Task<string> GetById(string id)
        {
            HttpResponseMessage response = await GetAsync(client.BaseAddress + config.AccountConfig.GetById + "?id=" + id);
            return await HandleResponse(response);
        }

        public async Task<int> Register(string username, string password, string email)
        {
            var parameters = new Dictionary<string, string> { { "username", username }, { "password", password },
            {"email", email }};

            HttpResponseMessage response = await PostAsync($"{client.BaseAddress}{config.AccountConfig.CreateAccount}", parameters);

            return (int)response.StatusCode;
        }

        public async Task<string> AddMoney(string id, string baseCurrency, string amount)
        {
            var parameters = new Dictionary<string, string> { { "id", id }, { "baseCurrency", baseCurrency },
            {"amount", amount } };
            HttpResponseMessage responseMessage = await PostAsync($"{client.BaseAddress}{config.AccountConfig.AddMoney}", parameters);

            return await HandleResponse(responseMessage);
        }

        public async Task<string> GetNotifications(string id)
        {
            
            HttpResponseMessage responseMessage = await GetAsync($"{client.BaseAddress}{config.AccountConfig.GetNotifications}?id={id}");

            return await HandleResponse(responseMessage);
        }

        public async Task<string> Login(string email, string password)
        {
            var parameters = new Dictionary<string, string> { { "email", email }, { "password", password } };

            

            HttpResponseMessage response = await PostAsync($"{client.BaseAddress}{config.AccountConfig.Login}", parameters);
            
            return GetJwtToken(response);
        }

        private string GetJwtToken(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("Set-Cookie", out var cookieValues))
            {
                return cookieValues.FirstOrDefault();
            }
            return null;
        }

        
    }
}
