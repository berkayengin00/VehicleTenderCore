using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.DAL.Abstract;

namespace VehicleTenderCore.BLL.Concrete
{
    public class VehicleManager:IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        public List<SelectListItem> GetAllVehicleByUserType(int userId)
        {
           return _vehicleDal.GetAllVehicleByUserType(userId);
        }
    }
}
