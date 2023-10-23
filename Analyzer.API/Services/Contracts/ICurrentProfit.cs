using Analyzer.API.Models;

namespace Analyzer.API.Services.Contracts
{
	public interface ICurrentProfit
	{
		decimal GetCurrentProfit(List<PortfolioItem> portfolio, decimal initialInvestment);
		
		
		
	}
}
