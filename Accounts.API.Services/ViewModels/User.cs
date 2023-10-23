using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.ViewModels
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public User(string username,string email,decimal balance)
        { 
            Username = username;
            Email = email;
            Balance = balance;
        }
    }
}
