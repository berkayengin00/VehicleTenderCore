using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTender.Entity.View;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
	[Authorize]
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
			var userType = GetUserBySession().UserType;
			var list = await _tenderApiProvider.TenderGetAll(userType);
			if (list.StatusCode == HttpStatusCode.OK)
			{
				return View(list.Data);
			}

			return BadRequest();
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View(new TenderAddVM());
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Add(TenderAddVM vm)
		{
			var user = GetUserBySession();
			vm.TenderTypeId = user.UserType;
			vm.CreatedById = vm.UpdatedById = user.UserId;

			TempData.Put("user", user);
			return RedirectToAction("Add", "TenderDetail");
		}

		[HttpGet]
		public async Task<IActionResult> GetTenderByUserId(int id)
		{
			var list = await _tenderApiProvider.TenderGetAllByUserId(id);
			if (list.StatusCode == HttpStatusCode.OK)
			{
				return View(list.Data);
			}
			return BadRequest();
		}

		private SessionVMForUser GetUserBySession()
		{
			return SessionExtension.MySessionGet<SessionVMForUser>(HttpContext.Session, "user");
		}
	}
}
