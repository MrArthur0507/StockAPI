using Gateway.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IAccountsService
    {
        public Task<string> GetAll();

        public Task<string> GetById(string id);

        public Task<int> Register(string username, string password, string email);

        public Task<string> Login(string username, string password);

        public Task<string> AddMoney(string id, string baseCurrency, string quantity);

        public Task<string> GetNotifications(string id);
    }
}
