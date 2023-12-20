using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.Implementation
{
    public class LoggerLogic:ILoggerLogic
    {

        private const string loginLogfile = "D:\\Games";
        private const string regLogFile = "D:\\Games";


        public void SaveLogin(User user)
        {
            Console.WriteLine($"User with username: {user.Username} logged at {GetDate()}");
        }
        public void SaveRegister(User user)
        {
            Console.WriteLine($"User with username: {user.Username}, email:{user.Email} register at {GetDate()}");
        }
        public void SaveLoginInFile(User user)
        {
            using (StreamWriter streamWriter = File.AppendText(loginLogfile))
            {
                streamWriter.WriteLine($"User with username: {user.Username} logged at {GetDate()}");
            }
        }
        public void SaveRegInFile(User user)
        {
            using (StreamWriter streamWriter = File.AppendText(regLogFile))
            {
                streamWriter.WriteLine($"User with username: {user.Username} and email: {user.Email} registered at {GetDate()}");
            }
        }
        private DateTime GetDate()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
