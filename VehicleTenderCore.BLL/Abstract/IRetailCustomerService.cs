using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface IRetailCustomerService
    {
        void Register(RetailCustomerRegisterVM vm);
    }
}
