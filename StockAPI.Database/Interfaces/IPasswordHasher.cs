using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Database.Interfaces
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password, out byte[] salt);
        public bool VerifyPassword(string password, string hash, byte[] salt);
    }
}
