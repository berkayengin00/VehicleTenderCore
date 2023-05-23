using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View.Vehicle;

namespace VehicleTenderCore.DAL.Concrete
{
    public class VehicleDal : EfCrudRepository<Vehicle>, IVehicleDal
    {
        private readonly EfVehicleContext _db;
        public VehicleDal(EfVehicleContext db) : base(db)
        {
            _db = db;
        }

        public List<SelectListItem> GetAllVehicleByUserType(int userId)
        {

            return (_db.Vehicles.Where(x=>x.UserId==userId).Select(x => new SelectListItem()
            {
                Text = x.LicensePlate,
                Value = x.Id.ToString()
            })).ToList();

        }
		/// <summary>
		/// Parametre olarak gelen araç id'sine göre araç detaylarını getirir.
		/// </summary>
		/// <param name="vehicleId"></param>
		/// <returns></returns>
        public VehicleDetailVM GetVehicleDetail(int vehicleId)
        {
	        return  (from vehicle in _db.Vehicles
		        join model in _db.Models on vehicle.ModelId equals model.Id
		        join brand in _db.Brands on model.BrandId equals brand.Id
		        join gearType in _db.GearTypes on vehicle.GearTypeId equals gearType.Id
		        join fuelType in _db.FuelTypes on vehicle.FuelTypeId equals fuelType.Id
		        join bodyType in _db.BodyTypes on vehicle.BodyTypeId equals bodyType.Id
				where vehicle.Id == vehicleId
		        select new VehicleDetailVM()
		        {
			        ModelName = model.ModelName,
			         BrandName= brand.BrandName,
			        Version = vehicle.Version,
			        KiloMeter = vehicle.KiloMeter,
			        Description = vehicle.Description,
			        BodyTypeName = bodyType.Name,
			        FuelTypeName = fuelType.Name,
			        GearTypeName = gearType.Name,
			        LicensePlate = vehicle.LicensePlate
		        }).SingleOrDefault();
		}
    }
}
