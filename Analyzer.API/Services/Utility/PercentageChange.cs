using Analyzer.API.Models;
using Analyzer.API.Services.Contracts;

namespace Analyzer.API.Services.Utility
{
    public class PercentageChange : IPercentageChange
    {
		private readonly ICurrentProfit _currentProfit;
		public PercentageChange(ICurrentProfit currentProfit) 
		{
			_currentProfit = currentProfit;
		}
		public async Task<decimal> CalculatePercentageChange(decimal futureBalance, string accountId)
		{
			decimal currentBalance=await _currentProfit.GetCurrentProfit(accountId);
			var change = futureBalance-currentBalance;
			var percentageChange = change/futureBalance;
			var final = percentageChange * 100;
			return final;
		}
	}
}
