using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface IRetailCustomerService
    {
        Result Register(RetailCustomerRegisterVM vm);
    }
}
