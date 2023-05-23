using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.BLL.Abstract
{
	public interface IRetailCustomerService
	{
		DataResult<SessionVMForUser> CheckRetailCustomer(RetailCustomerLoginVM vm);
		Result Register(RetailCustomerRegisterVM vm);
	}
}
