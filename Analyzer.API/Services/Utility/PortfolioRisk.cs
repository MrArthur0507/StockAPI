
using Analyzer.API.Models;
using Analyzer.API.Services.Contracts;
using Newtonsoft.Json;

public class PortfolioRisk :IPortfolioRisk
{
	private readonly ICurrentProfit _currentProfit;
	public PortfolioRisk(ICurrentProfit currentProfit)
	{
		_currentProfit = currentProfit;
	}

	public async Task<string> CheckBalanceRisk(string accountId)
	{
		decimal balance = await _currentProfit.GetCurrentProfit(accountId);
		if (balance < 10)
		{
			return "Dangerously low balance";
		}
		else if (balance < 20)
		{
			return "Excessively low balance";
		}
		else if (balance < 30)
		{
			return "Low balance";
		}
		else
		{
			return "The balance is within normal limits";
		}
	}
}
