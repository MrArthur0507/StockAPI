using Microsoft.AspNetCore.Mvc;

namespace Analyzer.API.Controllers
{
	public class PortfolioRiskController : Controller
	{
		[HttpGet("analyzer/portfolio-risk")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
