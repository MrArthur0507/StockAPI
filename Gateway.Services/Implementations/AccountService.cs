using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AccountService : IAccountsService
    {
        private readonly IConfigurationService _config;
        public AccountService(IConfigurationService config) { 
            _config= config;
        }

        
    }
}
