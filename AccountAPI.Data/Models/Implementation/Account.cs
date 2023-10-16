using AccountAPI.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class Account:BaseModel,IAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public virtual List<Stock> Stocks { get; set; } = new List<Stock>();
        public Account(string username,string password,string email,decimal balance) 
        {
            Username = username;
            Password = password;
            Email = email;
            Balance = balance;
        }
    }
}
