using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.BLL.Concrete
{
	public class CorporateCustomerManager:ICorporateCustomerService
	{
		private readonly ICorporateCustomerDal _corporateCustomerDal;
		public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal)
		{
			_corporateCustomerDal = corporateCustomerDal;
		}
		public DataResult<SessionVMForUser> CheckCorporateCustomer(CorporateCustomerLoginVM vm)
		{
			var result = _corporateCustomerDal.CheckCorporateCustomer(vm);
			if (result!=null)
			{
				return new DataResult<SessionVMForUser>("Kullanıcı Kayıtlı", result, true);
			}
			return new DataResult<SessionVMForUser>("Sistemde Tanımlı Kullanıcı Bulunamadı", result, false);

		}
	}
}
