namespace Analyzer.API.Services.Contracts
{
	public interface IPortfolioRisk
	{
		Task<string> CheckBalanceRisk(string accountId);
	}
}
