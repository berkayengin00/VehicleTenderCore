using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using VehicleTender.Entity.View;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.SessionExtensions;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
    public class TenderDetailController : Controller
    {
        private readonly VehicleApiProvider _vehicleApiProvider;
        public TenderDetailController(VehicleApiProvider vehicleApiProvider)
        {
            _vehicleApiProvider = vehicleApiProvider;
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

        [HttpPost]
        public IActionResult Add(string jsonData)
        {
	        var test = TempData.Get<TenderAddVM>("tender");
            // tempdata da tender varsa devam et
            if (TempData.TryGetValue("tender",out object value))
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
            return SessionExtension.MySessionGet<SessionVMForUser>(HttpContext.Session,"user").UserId;
        }
    }
}
