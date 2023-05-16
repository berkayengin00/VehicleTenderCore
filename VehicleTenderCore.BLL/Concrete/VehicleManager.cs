using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View.Vehicle;

namespace VehicleTenderCore.BLL.Concrete
{
    public class VehicleManager:IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public DataResult<VehicleDetailVM> GetVehicleDetail(int vehicleId)
        {
	        var result = _vehicleDal.GetVehicleDetail(vehicleId);
	        if (result!=null)
	        {
		        return new DataResult<VehicleDetailVM>("Araç Detayları Getirildi", result, true);
	        }
	        return new DataResult<VehicleDetailVM>("Araç Detayları Getirilemedi!!!", result, false);
        }

        public List<SelectListItem> GetAllVehicleByUserType(int userId)
        {
           return _vehicleDal.GetAllVehicleByUserType(userId);
        }
    }
}
