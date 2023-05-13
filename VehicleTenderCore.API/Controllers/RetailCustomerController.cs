using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailCustomerController : ControllerBase
    {
        private readonly IRetailCustomerDal _retailCustomerDal;
        public RetailCustomerController(IRetailCustomerDal retailCustomerDal)
        {
            _retailCustomerDal = retailCustomerDal;
        }


        [HttpPost]
        public IActionResult Register([FromBody] RetailCustomerRegisterVM vm)
        {
            _retailCustomerDal.Register(vm);
            return Ok();
        }   
    }
}
