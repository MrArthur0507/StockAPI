namespace Analyzer.API.Services.Contracts
{
	public interface ICurrentProfit
	{
		Task<decimal> GetCurrentProfit(string userId);
	}
}
