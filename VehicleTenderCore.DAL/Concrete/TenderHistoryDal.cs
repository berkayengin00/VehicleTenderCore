using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;

namespace VehicleTenderCore.DAL.Concrete
{
    public class TenderHistoryDal:EfCrudRepository<TenderHistory>,ITenderHistoryDal
    {
        private readonly EfVehicleContext _db;
        public TenderHistoryDal(EfVehicleContext db) : base(db)
        {
            _db = db;
        }
    }
}
