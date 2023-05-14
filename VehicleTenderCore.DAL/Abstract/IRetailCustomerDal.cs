using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.DAL.Abstract
{
    public interface IRetailCustomerDal:ICrudRepository<RetailCustomer>
    {
        SessionVMForUser CheckRetailCustomer(RetailCustomerLoginVM vm);
        void Register(RetailCustomerRegisterVM vm);
    }
}
