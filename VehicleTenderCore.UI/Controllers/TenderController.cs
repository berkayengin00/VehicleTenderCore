using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleTender.Entity.View;
using VehicleTenderCore.Core.SessionExtensions;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
    public class TenderController : Controller
    {
        private readonly TenderApiProvider _tenderApiProvider;
        public TenderController(TenderApiProvider tenderApiProvider)
        {
            _tenderApiProvider = tenderApiProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.UserTypeId = SessionExtension.MySessionGet<SessionVMForUser>(HttpContext.Session, "user").UserType;
            var list = await _tenderApiProvider.TenderGetAll(ViewBag.UserTypeId);
            return View(list.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
			return View(new TenderAddVM());
		}

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(TenderAddVM vm)
        {
	        var user =GetUserBySession();
            vm.TenderTypeId = user.UserType;
            vm.CreatedById = vm.UpdatedById = user.UserId;

            TempData.Put("user",user);
            return RedirectToAction("Add","TenderDetail");
        }

        private SessionVMForUser GetUserBySession()
        {
            return SessionExtension.MySessionGet<SessionVMForUser>(HttpContext.Session, "user");
        }
    }
}
