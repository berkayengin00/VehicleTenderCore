using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.DAL.Abstract
{
    public interface ICorporateCustomerDal
    {
        SessionVMForUser CheckCorporateCustomer(CorporateCustomerLoginVM vm);
    }
}
