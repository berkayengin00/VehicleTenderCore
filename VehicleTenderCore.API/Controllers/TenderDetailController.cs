using Microsoft.AspNetCore.Mvc;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.API.Controllers
{
    public class TenderDetailController : Controller
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
    }
}
