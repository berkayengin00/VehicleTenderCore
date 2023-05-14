using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;

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
    }
}
