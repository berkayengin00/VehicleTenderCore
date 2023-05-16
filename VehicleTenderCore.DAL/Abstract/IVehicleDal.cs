using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View.Vehicle;

namespace VehicleTenderCore.DAL.Abstract
{
    public interface IVehicleDal:ICrudRepository<Vehicle>
    {
        List<SelectListItem> GetAllVehicleByUserType(int userId);
        VehicleDetailVM GetVehicleDetail(int vehicleId);
    }
}
