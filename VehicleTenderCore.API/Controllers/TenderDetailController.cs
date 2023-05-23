using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TenderDetailController : ControllerBase
	{
		private readonly ITenderService _tenderService;

		public TenderDetailController(ITenderService tenderService)
		{
			_tenderService = tenderService;
		}

		[HttpPost]
		public IActionResult Add([FromBody] TenderAndDetailsVM vm)
		{
			var result = _tenderService.TenderAndDetailsAdd(vm);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid/{id}")]
		public IActionResult GetByTenderId(int id)
		{
			var result = _tenderService.GetTenderDetail(id);
			if (!result.IsSuccess)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

        [HttpGet("GetDetailForCorporate/{id}")]
        public IActionResult GetDetailForCorporate(int id)
        {
            var result = _tenderService.GetForCorporate(id);
            if (!result.IsSuccess)
			{
				return BadRequest(result);
			}
			return Ok(result);
        }
    }
}
