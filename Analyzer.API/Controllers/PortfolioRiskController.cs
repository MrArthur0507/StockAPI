using Microsoft.AspNetCore.Mvc;
using Analyzer.API.Services.Contracts;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PortfolioRiskController : ControllerBase
{
	private readonly IPortfolioRisk _portfolioRiskService;
	public PortfolioRiskController(IPortfolioRisk portfolioRiskService)
	{
		_portfolioRiskService = portfolioRiskService;
	}

	[HttpGet]
	public async Task<string> GetRiskMessage(string userId)
	{
		var riskMessage = await _portfolioRiskService.CheckBalanceRisk(userId);
		return riskMessage;
	}
}
