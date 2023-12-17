using Microsoft.AspNetCore.Http.HttpResults;
using Settlement.Infrastructure.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Settlement.Infrastructure.SettlementContracts;

namespace Settlement.Infrastructure.SettlementServices
{
    public class CheckAccountCreditsService : ICheckAccountCreditsService
    {
        public bool CheckBalance(Account account, double stockPrice, int quantity)
        {
            return account.Balance < Convert.ToDecimal(stockPrice * quantity);
        }
    }
}
