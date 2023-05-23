using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
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

        public DataResult<List<TenderDetailAndBidVM>> GetTenderDetailAndBid(int userId)
        {
	        var result = _tenderHistoryDal.GetTenderDetailAndBid(userId);
	        if (result!=null)
	        {
		        return new DataResult<List<TenderDetailAndBidVM>>("",result, true);
	        }
	        return new DataResult<List<TenderDetailAndBidVM>>("", result, false);
        }
        
        public void Test2()
        {
            _tenderHistoryDal.Test2();
        }
    }
}
