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

        public Task<int> Register(string username, string password, string email, string balance);
    }
}
