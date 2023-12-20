using Settlement.Infrastructure.Models.SettlementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementContracts
{
    public interface ISqliteGetTransactionsService
    {
        public Task<List<TransactionStorage>> GetTransactions();
    }
}
