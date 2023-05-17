using Microsoft.AspNetCore.Mvc;

namespace VehicleTenderCore.UI.Controllers
{
	public class ErrorController : Controller
	{
		[HttpGet]
		public IActionResult Page404()
		{
			return View();
		}


		[HttpGet]
		public IActionResult Page500()
		{
			return View();
		}
	}
}
