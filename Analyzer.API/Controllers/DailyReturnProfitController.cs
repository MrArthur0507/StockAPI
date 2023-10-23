using Microsoft.AspNetCore.Mvc;

namespace Analyzer.API.Controllers
{
	public class DailyReturnProfitController : Controller
	{
		
		[HttpGet("analyzer/daily-return-profit")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
