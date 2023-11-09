using Analyzer.API.Models;
using Analyzer.API.Services.Contracts;

namespace Analyzer.API.Services.Utility
{
	public class CurrentProfit : ICurrentProfit
	{
		public decimal GetCurrentProfit(List<PortfolioItem> portfolio, decimal initialInvestment)
		{
			decimal currentTotalValue = 0;
			foreach (var item in portfolio)
			{
				decimal currentPrice = GetStockPriceBySymbol(item.Symbol);

				decimal currentValue = currentPrice * item.Quantity;
				currentTotalValue += currentValue;
			}

			decimal currentProfit = currentTotalValue - initialInvestment;
			return currentProfit;
		}

		private decimal GetStockPriceBySymbol(string symbol)
		{
			return 0; 
		}
	}
}
