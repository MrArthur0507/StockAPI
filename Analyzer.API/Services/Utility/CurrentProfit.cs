using Analyzer.API.Models;
using Analyzer.API.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Analyzer.API.Services.Utility
{
    internal class CurrentProfit : ICurrentProfit
    {
		private readonly IStockService _stockService;
		public CurrentProfit(IStockService stockService)
		{
			_stockService = stockService;
		}
		public decimal GetCurrentProfit(List<PortfolioItem> portfolio, decimal initialInvestment)
		{
			decimal currentTotalValue = 0;
			foreach (var item in portfolio)
			{
				decimal currentPrice = _stockService.GetCurrentPrice(item.Symbol);
				decimal currentValue = currentPrice * item.Quantity;
				currentTotalValue += currentValue;
			}

			decimal currentProfit = currentTotalValue - initialInvestment;
			return currentProfit;
		}


	}
}
