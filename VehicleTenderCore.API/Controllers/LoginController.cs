using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRetailCustomerDal _retailCustomerDal;
        private readonly ICorporateCustomer _corporateCustomer;
        public LoginController(IRetailCustomerDal retailCustomerDal, ICorporateCustomer corporateCustomer)
        {
            _retailCustomerDal = retailCustomerDal;
            _corporateCustomer = corporateCustomer;
        }

        [HttpPost("loginretail")]
        public IActionResult Login([FromBody] RetailCustomerLoginVM vm)
        {
            var result = _retailCustomerDal.CheckRetailCustomer(vm);
            if (result!=null)
            {
				return Ok(result);
			}

            return BadRequest(result);
        }

        [HttpPost("logincorporate")]
        public IActionResult Login([FromBody] CorporateCustomerLoginVM vm)
        {
            var result = _corporateCustomer.CheckCorporateCustomer(vm);
            if (result!=null)
            {
	            return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
