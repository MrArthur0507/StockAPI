using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
    public interface IEmailRepository
    {
        public int IsEmailValid(string email);
    }
}
