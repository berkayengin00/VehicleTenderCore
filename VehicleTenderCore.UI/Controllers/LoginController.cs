using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Extensions;
using VehicleTenderCore.UI.Providers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

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
	            AuthenticationAsync(user.Data);
				HttpContext.Session.MySessionSet("user", user.Data);
                return RedirectToAction("Index","Tender");
            }

            return BadRequest(user.Message);
        }
        

        [HttpPost]
        public async Task<IActionResult> LoginCorporate(CorporateCustomerLoginVM vm)
        {
            var user = await _loginApiProvider.CheckCorporateCustomerAsync(vm);
            if (user.StatusCode == HttpStatusCode.OK)
            {
	            AuthenticationAsync(user.Data);
                HttpContext.Session.MySessionSet("user", user.Data);
                return RedirectToAction("Index", "Tender");
            }
            return BadRequest(user.Message);
        }


        public async Task AuthenticationAsync(SessionVMForUser vm)
        {
	        var claims = new[] { new Claim(ClaimTypes.Name, vm.Email) };

	        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

	        await HttpContext.SignInAsync(
		        CookieAuthenticationDefaults.AuthenticationScheme,
		        new ClaimsPrincipal(identity));
		}

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
	        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
	        HttpContext.Session.Clear();
	        return RedirectToAction("Login");
		}
    }
}
