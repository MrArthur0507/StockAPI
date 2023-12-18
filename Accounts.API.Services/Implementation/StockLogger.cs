using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class StockLogger:IStockLogger
    {
        private readonly ILoggerLogic _logic;
        public StockLogger(ILoggerLogic logic)
        {
            _logic = logic;
        }

        public void SaveLogin(User user)
        {
            _logic.SaveLogin(user);
        }
        public void SaveRegister(User user)
        {
            _logic.SaveRegister(user);
        }
        public void SaveLoginInFile(User user)
        {
            _logic.SaveLoginInFile(user);
        }

        public void SaveRegInFile(User user)
        {
            _logic.SaveRegInFile(user);
        }
        public void GetDate()
        {
            Console.WriteLine(DateTime.Now.ToUniversalTime());
        }
    }
}
