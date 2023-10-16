using AccountAPI.Data.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Interfaces
{
    public interface IAccount:IBaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string Salt { get; set; }
        //public ICollection<Stock> Stocks { get; set; }

    }
}
