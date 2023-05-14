using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View.RetailCustomer;
using VehicleTenderCore.UI.Providers;

namespace VehicleTenderCore.UI.Controllers
{
    public class RetailCustomerController : Controller
    {
        private readonly RetailCustomerApiProvider _retailCustomerApiProvider;
        public RetailCustomerController(RetailCustomerApiProvider retailCustomerApiProvider)
        {
            _retailCustomerApiProvider = retailCustomerApiProvider;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RetailCustomerRegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RetailCustomerRegisterVM vm)
        {
            var result =  await _retailCustomerApiProvider.RegisterAsync(vm);

            if (result.StatusCode==HttpStatusCode.OK)
            {
                 return RedirectToAction("Login","Login");
            }

            return BadRequest(result.Message);
        }   
    }
}
