using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.BLL.Abstract;

namespace VehicleTenderCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("getall/{id}")]
        public IActionResult GetAllByUserType(int id)
        {
            var list =_vehicleService.GetAllVehicleByUserType(id);
            return Ok(list);
        }
    }
}
