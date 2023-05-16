using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View.Vehicle;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface IVehicleService
    {
        DataResult<VehicleDetailVM> GetVehicleDetail(int vehicleId);
        List<SelectListItem> GetAllVehicleByUserType(int userId);
    }
}
