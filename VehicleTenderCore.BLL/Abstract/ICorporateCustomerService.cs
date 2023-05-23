using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.BLL.Abstract
{
	public interface ICorporateCustomerService
	{
		DataResult<SessionVMForUser> CheckCorporateCustomer(CorporateCustomerLoginVM vm);
	}
}
