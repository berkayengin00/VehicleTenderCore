using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.BLL.Concrete;
using VehicleTenderCore.DAL.Context;

namespace VehicleTenderCore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehicleController : ControllerBase
	{
		private readonly IVehicleService _vehicleService;
		private readonly HangfireDal _hangfireDal;
		public VehicleController(IVehicleService vehicleService, HangfireDal hangfireDal)
		{
			_vehicleService = vehicleService;
			_hangfireDal = hangfireDal;
		}

		[HttpGet("getall/{id}")]
		public IActionResult GetAllByUserType(int id)
		{
			var list = _vehicleService.GetAllVehicleByUserType(id);
			return Ok(list);
		}

		[HttpGet("getByVehicleId/{id}")]
		public IActionResult GetByVehicleId(int id)
		{
			var result = _vehicleService.GetVehicleDetail(id);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		[HttpGet("test")]
		public IActionResult Test()
		{
			_hangfireDal.CheckTenderStatus();
			return Ok();
		}
	}
}
