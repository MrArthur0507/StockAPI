using Microsoft.AspNetCore.Mvc;

namespace Analyzer.API.Controllers
{
	public class PercentageChangeController : Controller
	{
		[HttpGet("analyzer/percentage-change")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
