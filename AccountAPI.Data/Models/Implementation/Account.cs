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
        public string UserType { get; set; }
        public string Salt { get; set; }
       // public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        public Account()
        {
        }
        public Account(string username,string password,string email,decimal balance,string salt) 
        {
            Username = username;
            Password = password;
            Email = email;
            Balance = balance;
            Salt = salt;
            UserType = "Normal";
        }
    }
}
