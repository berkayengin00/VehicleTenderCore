using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailCustomerController : ControllerBase
    {
        private readonly IRetailCustomerService _retailCustomerService;
        public RetailCustomerController(IRetailCustomerService retailCustomerService)
        {
            _retailCustomerService = retailCustomerService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RetailCustomerRegisterVM vm)
        {
            _retailCustomerService.Register(vm);
            return Ok();
        }
    }
}
