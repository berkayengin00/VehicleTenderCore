using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.BLL.Abstract;
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

        public void Add(TenderOfferAddVM vm)
        {
            var result = _mapper.Map<TenderHistory>(vm);
            _tenderHistoryDal.Insert(result);
        }
    }
}
