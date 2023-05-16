using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.BLL.Concrete
{
    public class RetailCustomerManager : IRetailCustomerService
    {
        private readonly IRetailCustomerDal _retailCustomerDal;
        private readonly IMapper _mapper;
        public RetailCustomerManager(IRetailCustomerDal retailCustomerDal, IMapper mapper)
        {
            _retailCustomerDal = retailCustomerDal;
            _mapper = mapper;
        }


        public DataResult<SessionVMForUser> CheckRetailCustomer(RetailCustomerLoginVM vm)
        {
	        var result = _retailCustomerDal.CheckRetailCustomer(vm);
	        if (result!=null)
	        {
                return new DataResult<SessionVMForUser>("Kullanıcı Kayıtlı", result, true);
	        }
	        return new DataResult<SessionVMForUser>("Sistemle Tanımlı Kullanıcı Bulunamadı", result, false);
        }

        public Result Register(RetailCustomerRegisterVM vm)
        {
	        var result = _mapper.Map<RetailCustomer>(vm);
            var success = _retailCustomerDal.Insert(result) > 0;
            if (success)
            {
                return new Result("Kayıt Başarılı", true);
            }
            return new Result("Kayıt Başarısız", false);
        }
    }
}
