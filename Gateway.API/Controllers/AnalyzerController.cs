using Gateway.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzerController : ControllerBase
    {
        private readonly IAnalyzerService _analyzerService;
        public AnalyzerController(IAnalyzerService analyzerService)
        {
            _analyzerService = analyzerService;
        }

        [HttpGet]
        [Authorize]
        [Route("balance")]
        public async Task<IActionResult> CurrentProfit(string accountId)
        {
            return Ok(await _analyzerService.GetBalance(accountId));
        }

        [HttpGet]
        [Authorize]
        [Route("percentageChange")]
        public async Task<IActionResult> PercentageChange(string futureBalance, string accountId)
        {
            return Ok(await _analyzerService.PercentageChange(futureBalance, accountId));
        }

        [HttpGet]
        [Authorize]
        [Route("portfolioRisk")]
        public async Task<IActionResult> PortfolioRisk(string accountId)
        {

            return Ok(await _analyzerService.PortfolioRisk(accountId));
        }
    }
}
