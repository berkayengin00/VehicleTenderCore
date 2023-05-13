using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.UI.Controllers
{
    public class RetailCustomerController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RetailCustomerRegisterVM());
        }

        [HttpPost]
        public IActionResult Register(RetailCustomerRegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }   
    }
}
