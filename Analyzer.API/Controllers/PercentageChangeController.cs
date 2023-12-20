using Microsoft.AspNetCore.Mvc;
using Analyzer.API.Services.Contracts;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PercentageChangeController : ControllerBase
{
	private readonly IPercentageChange _percentageChangeService;

	public PercentageChangeController(IPercentageChange percentageChangeService)
	{
		_percentageChangeService = percentageChangeService;
	}
	[HttpGet]
	public async Task<decimal> GetPercentageChange(decimal futureBalance, string accountId)
	{
		var percentageChange = await _percentageChangeService.CalculatePercentageChange(futureBalance, accountId);
		return percentageChange;
	}
}
