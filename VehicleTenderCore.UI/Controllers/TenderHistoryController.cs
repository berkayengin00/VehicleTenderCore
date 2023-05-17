using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.TenderHistory;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
    [Authorize]
    public class TenderHistoryController : Controller
    {
        private readonly TenderHistoryApiProvider _tenderHistoryApiProvider;
        public TenderHistoryController(TenderHistoryApiProvider tenderHistoryApiProvider)
        {
            _tenderHistoryApiProvider = tenderHistoryApiProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TenderOfferAddVM vm)
        {
            vm.UserId = HttpContext.Session.MySessionGet<SessionVMForUser>("user").UserId;
            var result = await _tenderHistoryApiProvider.TenderOfferAdd(vm);
            if (result.StatusCode == HttpStatusCode.OK)
            {
	            TempData.Add("message", result.Message);
	            return RedirectToAction("GetByTenderId","TenderDetail",new {tenderId=vm.TenderId});
			}
            return RedirectToAction("Index","Tender");
        }

        [HttpGet]
        public async Task<IActionResult> GetForCorporate(int tenderId)
        {
	        var result = await _tenderHistoryApiProvider.GetForCorporate(tenderId);
	        if (result.StatusCode == HttpStatusCode.OK)
	        {
		        return View(result.Data);
	        }
	        return RedirectToAction("Index", "Tender");
        }

	}
}
