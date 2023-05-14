using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TenderDetailController : ControllerBase
	{
		private readonly ITenderDal _tenderDal;

		public TenderDetailController(ITenderDal tenderDal)
		{
			_tenderDal = tenderDal;
		}

		[HttpPost]
		public IActionResult Add([FromBody] TenderAndDetailsVM vm)
		{
			_tenderDal.TenderAndDetailsAdd(vm);
			return Ok();
		}

		[HttpGet("getbyid/{id}")]
		public IActionResult GetByTenderId(int id)
		{
			var result = _tenderDal.GetTenderDetail(id);
			return Ok(result);
		}
	}
}
