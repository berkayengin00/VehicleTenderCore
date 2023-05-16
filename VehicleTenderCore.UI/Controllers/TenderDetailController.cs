using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using VehicleTender.Entity.View;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
	[Authorize]
	public class TenderDetailController : Controller
	{
		private readonly VehicleApiProvider _vehicleApiProvider;
		private readonly TenderDetailApiProvider _tenderDetailApiProvider;
		public TenderDetailController(VehicleApiProvider vehicleApiProvider, TenderDetailApiProvider tenderDetailApiProvider)
		{
			_vehicleApiProvider = vehicleApiProvider;
			_tenderDetailApiProvider = tenderDetailApiProvider;
		}

		[HttpGet]
		public IActionResult Add()
		{

			TenderDetailAddVM result = new TenderDetailAddVM()
			{
				Vehicles = _vehicleApiProvider.VehicleGetAll(GetUserId()).Result.Data
			};
			return View(result);
		}


		[HttpGet]
		public async Task<IActionResult> GetByTenderId(int tenderId)
		 {
			var result = await _tenderDetailApiProvider.TenderDetailsGet(tenderId);
            if (result.StatusCode==HttpStatusCode.OK)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index", "Tender");
        }


		[HttpPost]
		public IActionResult Add(string jsonData)
		{
			var test = TempData.Get<TenderAddVM>("tender");
			// tempdata da tender varsa devam et
			if (TempData.TryGetValue("tender", out object value))
			{
				value = TempData["tender"] as TenderAddVM;

				var data = JsonConvert.DeserializeObject<List<TenderDetailAddVM>>(jsonData);
				new TenderAndDetailsVM()
				{
					TenderAddVM = TempData["tender"] as TenderAddVM,
					TenderDetailAddVM = data
				};
			}
			return View();
		}

		public int GetUserId()
		{
			return SessionExtension.MySessionGet<SessionVMForUser>(HttpContext.Session, "user").UserId;
		}
	}
}
