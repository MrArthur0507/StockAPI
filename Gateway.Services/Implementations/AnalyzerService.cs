using Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Services.Implementations
{
    public class AnalyzerService : IAnalyzerService
    {
        private readonly IAnalyzerAPIService _analyzerAPIService;
        public AnalyzerService(IAnalyzerAPIService analyzerAPIService)
        {
            _analyzerAPIService = analyzerAPIService;
        }

        public async Task<string> GetBalance(string accountId) => await _analyzerAPIService.GetBalance(accountId);

        public async Task<string> PercentageChange(string futureBalance, string accountId) => await _analyzerAPIService.PercentageChange(futureBalance, accountId);

        public async Task<string> PortfolioRisk(string accountId) => await PortfolioRisk(accountId);
        
    }
}
