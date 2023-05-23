using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.BLL.Mapper
{
    public class TenderHistoryProfile:Profile
    {
        public TenderHistoryProfile()
        {
            CreateMap<TenderOfferAddVM, TenderHistory>();
            CreateMap<TenderHistory, TenderOfferAddVM>();
        }
    }
}
