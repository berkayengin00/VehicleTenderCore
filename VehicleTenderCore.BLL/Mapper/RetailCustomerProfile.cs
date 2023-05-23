using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Entities.View.RetailCustomer;

namespace VehicleTenderCore.BLL.Mapper
{
    public class RetailCustomerProfile:Profile
    {
        public RetailCustomerProfile()
        {
            CreateMap<RetailCustomerRegisterVM, RetailCustomer>();
            CreateMap<RetailCustomer, RetailCustomerRegisterVM>();
        }
    }
}
