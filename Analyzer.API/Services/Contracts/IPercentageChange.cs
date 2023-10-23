using Analyzer.API.Models;

namespace Analyzer.API.Services.Contracts
{
	public interface IPercentageChange
	{
		decimal GetPercentageChange(List<PortfolioItem> portfolio, DateTime startDate, DateTime endDate);
	}
}
