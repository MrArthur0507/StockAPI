using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task<string> GetTransactionForUser(string id);

        public Task<string> GetTransactionByStock(string stockId);
    }
}
