using Analyzer.API.Models;
using Analyzer.API.Services.Contracts;

namespace Analyzer.API.Services.Utility
{
    internal class PercentageChange : IPercentageChange
    {
       private readonly IStockService _stockService;
        public PercentageChange(IStockService stockService)
        {
            _stockService = stockService;
        }
        public decimal GetPercentageChange(List<PortfolioItem> portfolio, DateTime starDate, DateTime endDate)
        {
            var startPrices=new Dictionary<string, decimal>();
            foreach(var item in portfolio)
            {
				if (string.IsNullOrEmpty(item.Symbol) || item.Quantity <= 0)
                {
					throw new ArgumentException("Invalid portfolio item.");

				}
				decimal startPrice = _stockService.GetPriceAtDate(item.Symbol, endDate);
				startPrices[item.Symbol] = startPrice;
            }
            decimal currentTotalValue = portfolio.Sum(item =>
            {
                decimal currentPrice = _stockService.GetPriceAtDate(item.Symbol, endDate);
                return currentPrice;
            });
            decimal initialTotalValue = portfolio.Sum(item => startPrices[item.Symbol] * item.Quantity);
			decimal percentageChange = ((currentTotalValue - initialTotalValue) / initialTotalValue) * 100;
			return percentageChange;
        }
    }
}
