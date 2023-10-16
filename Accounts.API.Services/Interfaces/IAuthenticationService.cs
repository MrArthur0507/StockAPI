using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public int Register(string username, string password, string email, decimal balance);

        public int Login(string email, string password);
    }
}
