using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Enum;
using VehicleTenderCore.Core.Hashing;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.DAL.Concrete
{
    public class CorporateCustomerDal:ICorporateCustomerDal
    {
        private readonly EfVehicleContext _db;
        public CorporateCustomerDal(EfVehicleContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Sistemde kayıtlı Kurumsal Müşteri var mı kontrol eder.
        /// Geriye Session bilgilerini döner.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public SessionVMForUser CheckCorporateCustomer(CorporateCustomerLoginVM vm)
        {
            var result = (from user in _db.CorporateCustomers
                where user.Email == vm.Email && user.PasswordHash == new MyHash().HashPassword(vm.Password) && user.IsVerify
                select new SessionVMForUser()
                {
                    Email = user.Email,
                    UserId = user.Id,
                    UserType = (int)UserTypeEnum.Corporate
                }).SingleOrDefault();
            return result;
        }
    }
}
