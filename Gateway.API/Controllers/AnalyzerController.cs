using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzerController : ControllerBase
    {
        [HttpGet]
        [Route("currentProfit")]
        public IActionResult CurrentProfit(string id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("dailyReturnProfit")]
        public IActionResult DailyReturnProfit(string id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("percentageChange")]
        public IActionResult PercentageChange(string id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("portfolioRisk")]
        public IActionResult PortfolioRisk(string id)
        {
            return Ok();
        }
    }
}
