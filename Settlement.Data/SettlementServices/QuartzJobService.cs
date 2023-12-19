using Quartz;
using SettlementServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlement.Infrastructure.SettlementServices
{
    public class QuartzJobService : IJob
    {
        private SqliteDeleteTransactionsService _sqliteDeleteTransactionsService;
        private SqliteGetTransactionsService _sqliteGetTransactionService;
        private TransactionStorageExecutionService _transactionStorageExecutionService;

        public QuartzJobService(SqliteGetTransactionsService sqliteGetTransactionsService,
            SqliteDeleteTransactionsService sqliteDeleteTransactionsService,
            TransactionStorageExecutionService transactionStorageExecutionService)
        {
            _sqliteGetTransactionService = sqliteGetTransactionsService;
            _sqliteDeleteTransactionsService = sqliteDeleteTransactionsService;
            _transactionStorageExecutionService = transactionStorageExecutionService;
        }


        public async Task Execute(IJobExecutionContext context)
        {
            await _transactionStorageExecutionService.StoreTransactions(_sqliteGetTransactionService.GetTransactions());
            await _sqliteDeleteTransactionsService.DeleteAllTransactions();
        }
    }
}
