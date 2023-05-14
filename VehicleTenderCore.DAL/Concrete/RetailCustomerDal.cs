using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.DAL.Concrete
{
    public class RetailCustomerDal : EfCrudRepository<RetailCustomer>,IRetailCustomerDal
    {
        private readonly EfVehicleContext _db;
        public RetailCustomerDal(EfVehicleContext db) : base(db)
        {
            _db = db;
        }

        public SessionVMForUser CheckRetailCustomer(RetailCustomerLoginVM vm)
        {
            var result = (from user in _db.RetailCustomers
                          where user.Email == vm.Email && user.PasswordHash == vm.Password
                          select new SessionVMForUser()
                          {
                              Email = user.Email,
                              UserId = user.Id,
                              UserType = (int)UserTypeEnum.Retired
                          }).SingleOrDefault();
            return result;
        }

        public void Register(RetailCustomerRegisterVM vm)
        {
            throw new NotImplementedException();
        }

        
    }
}
