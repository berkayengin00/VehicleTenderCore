using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.BLL.JWT;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;
using Microsoft.Extensions.Options;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRetailCustomerService _retailCustomerService;
        private readonly ICorporateCustomerService _corporateCustomerService;
		private IConfiguration _configuration;
		public LoginController(IRetailCustomerService retailCustomerService, ICorporateCustomerService corporateCustomerService, IConfiguration configuration)
        {
            _retailCustomerService = retailCustomerService;
			_corporateCustomerService = corporateCustomerService;
            _configuration = configuration;
        }

        [HttpPost("loginretail")]
        public IActionResult Login([FromBody] RetailCustomerLoginVM vm)
        {
            var result = _retailCustomerService.CheckRetailCustomer(vm);
            if (result.IsSuccess)
            {
	            result.Data.Token = new TokenHandler(_configuration).GetJwtToken(result.Data);
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
	            result.Data.Token = new TokenHandler(_configuration).GetJwtToken(result.Data);
                
	            return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
