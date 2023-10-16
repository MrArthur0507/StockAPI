using Microsoft.AspNetCore.Mvc;

namespace Analyzer.API.Controllers
{
	public class CurrentProfitController : Controller
	{
		[HttpGet("analyzer/current-profit")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
