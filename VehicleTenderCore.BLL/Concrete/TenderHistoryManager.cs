using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.BLL.Concrete
{
    public class TenderHistoryManager:ITenderHistoryService
    {
        private readonly ITenderHistoryDal _tenderHistoryDal;
        private readonly IMapper _mapper;
        public TenderHistoryManager(ITenderHistoryDal tenderHistoryDal, IMapper mapper)
        {
            _tenderHistoryDal = tenderHistoryDal;
            _mapper= mapper;
        }

        public Result Add(TenderOfferAddVM vm)
        {
            var result = _mapper.Map<TenderHistory>(vm);
            var success =_tenderHistoryDal.Insert(result)>0;
            if (success)
            {
	            return new Result("Teklif Verildi", true);
            }
            return new Result("Teklif Verilemedi", false);  
        }
    }
}
