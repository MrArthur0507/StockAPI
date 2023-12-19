using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Interfaces
{
    public interface IAnalyzerAPIService
    {
        public Task<string> GetBalance(string accountId);

        public Task<string> PercentageChange(string futureBalance, string accountId);

        public Task<string> PortfolioRisk(string accountId);
    }
}
