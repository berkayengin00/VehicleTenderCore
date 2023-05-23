using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [Authorize]
        [HttpGet("getall/{id}")]
        public IActionResult GetAll(int id)
        {
            var result =_tenderService.GetAllByUserType(id);
   
            if (result.IsSuccess)
            {
				return Ok(result);
			}
            return BadRequest(result);

        }

        
        [HttpGet("GetAllByUserId/{id}")]
        public IActionResult GetAllByUserId(int id)
        {
            var result = _tenderService.GetAllByUserId(id);
            if (result.IsSuccess)
            {
	            return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
