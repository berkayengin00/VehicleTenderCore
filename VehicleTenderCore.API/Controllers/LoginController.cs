using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRetailCustomerService _retailCustomerService;
        private readonly ICorporateCustomerService _corporateCustomerService;
        public LoginController(IRetailCustomerService retailCustomerService, ICorporateCustomerService corporateCustomerService)
        {
            _retailCustomerService = retailCustomerService;
			_corporateCustomerService = corporateCustomerService;
        }

        [HttpPost("loginretail")]
        public IActionResult Login([FromBody] RetailCustomerLoginVM vm)
        {
            var result = _retailCustomerService.CheckRetailCustomer(vm);
            if (result.IsSuccess)
            {
				return Ok(result);
			}

            return BadRequest(result);
        }

        [HttpPost("logincorporate")]
        public IActionResult Login([FromBody] CorporateCustomerLoginVM vm)
        {
            var result = _corporateCustomerService.CheckCorporateCustomer(vm);
            if (result.IsSuccess)
            {
	            return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
