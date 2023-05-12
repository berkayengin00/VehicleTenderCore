using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
	public class LoginController : Controller
    {
        private readonly LoginApiProvider _loginApiProvider;
        public LoginController(LoginApiProvider loginApiProvider)
        {
            _loginApiProvider = loginApiProvider;
        }

		[HttpGet]
		public IActionResult Login()
		{
			return View((new RetailCustomerLoginVM(),new CorporateCustomerLoginVM()));
		}

        [HttpPost]
        public async Task<IActionResult> LoginRetail(RetailCustomerLoginVM vm)
        {
            var user = await _loginApiProvider.CheckRetailCustomerAsync(vm);
            if (user.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Login");
            }

            return BadRequest(user.Message);
        }
        

        [HttpPost]
        public async Task<IActionResult> LoginCorporate(CorporateCustomerLoginVM vm)
        {
            var user = await _loginApiProvider.CheckCorporateCustomerAsync(vm);
            if (user.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Login");
            }

            return BadRequest(user.Message);
        }
    }
}
