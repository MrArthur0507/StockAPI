using Microsoft.AspNetCore.Mvc;
using Analyzer.API.Services.Contracts;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BalanceController : ControllerBase
{
	private readonly ICurrentProfit _currentProfit;

	public BalanceController(ICurrentProfit currentProfit)
	{
		_currentProfit = currentProfit;
	}

	[HttpGet("{userId}")]
	public async Task<ActionResult<decimal>> GetBalance(string userId)
	{
		var balance = await _currentProfit.GetCurrentProfit(userId);
		return balance;
	}
}
