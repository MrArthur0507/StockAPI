using Settlement.Infrastructure.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementContracts
{
    public interface ISqliteAddTransactionsService
    {
        public Task AddTransaction(Account account, double price, int quantity, string stockName);
    }
}
