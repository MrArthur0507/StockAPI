using Analyzer.API.Models;

namespace Analyzer.API.Services.Contracts
{
	public interface IPercentageChange
	{
	Task<decimal> CalculatePercentageChange(decimal futureBalance,string accountId);
	}
}
