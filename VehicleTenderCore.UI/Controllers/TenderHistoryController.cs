using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.TenderHistory;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
    public class TenderHistoryController : Controller
    {
        private readonly TenderHistoryApiProvider _tenderHistoryApiProvider;
        public TenderHistoryController(TenderHistoryApiProvider tenderHistoryApiProvider)
        {
            _tenderHistoryApiProvider = tenderHistoryApiProvider;
        }
        public async Task<IActionResult> Add(TenderOfferAddVM vm)
        {
            vm.UserId = HttpContext.Session.MySessionGet<SessionVMForUser>("user").UserId;
            var result = await _tenderHistoryApiProvider.TenderOfferAdd(vm);
            return RedirectToAction("Index","Tender");
        }
    }
}
