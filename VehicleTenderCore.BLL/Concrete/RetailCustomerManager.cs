using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.BLL.Concrete
{
    public class RetailCustomerManager:IRetailCustomerService
    {
        private readonly IRetailCustomerDal _retailCustomerDal;
        private readonly IMapper _mapper;
        public RetailCustomerManager(IRetailCustomerDal retailCustomerDal, IMapper mapper)
        {
            _retailCustomerDal = retailCustomerDal;
            _mapper = mapper;
        }


        public void Register(RetailCustomerRegisterVM vm)
        {
            //mapleme işlemi yapılacak
           var result = _mapper.Map<RetailCustomer>(vm);
           _retailCustomerDal.Insert(result);
        }
    }
}
