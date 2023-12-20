using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IAccountAPIService
    {
        Task<string> GetAll();
        Task<string> GetById(string id);
        Task<int> Register(string username, string password, string email, string balance);
        Task<string> Login(string email, string password);

        Task<string> AddMoney(string id, string baseCurrency, string amount);

        Task<string> GetNotifications(string id);
    }
}
