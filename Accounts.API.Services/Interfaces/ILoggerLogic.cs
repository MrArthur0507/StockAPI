using Accounts.API.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Interfaces
{
    public interface ILoggerLogic
    {

        public void SaveLogin(User user);
        public void SaveRegister(User user);
        public void SaveLoginInFile(User user);
        public void SaveRegInFile(User user);
    }
}
