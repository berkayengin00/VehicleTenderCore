using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
	public class VehicleController : Controller
	{
		private readonly VehicleApiProvider _vehicleApiProvider;
		public VehicleController(VehicleApiProvider vehicleApiProvider)
		{
			_vehicleApiProvider = vehicleApiProvider;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int vehicleId)
		{
			var result = await _vehicleApiProvider.GetVehicleByTenderId(vehicleId);
			if (result.StatusCode==HttpStatusCode.OK)
			{
				return Json(result.Data);
			}
			return RedirectToAction("Index","Tender");
		}
	}
}
