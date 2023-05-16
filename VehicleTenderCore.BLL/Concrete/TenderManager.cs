using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.Tender;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.BLL.Concrete
{
    public class TenderManager : ITenderService
    {
        private readonly ITenderDal _tenderDal;

        public TenderManager(ITenderDal tenderDal)
        {
            _tenderDal = tenderDal;
        }

        public DataResult<List<TenderListVM>> GetAll()
        {
            var result= _tenderDal.GetAll();
            if (result==null)
            {
                return new DataResult<List<TenderListVM>>("Hata",result,false);
            }
            return new DataResult<List<TenderListVM>>("Başarılı", result, true);
        }

        public DataResult<List<TenderListVM>> GetAllByUserType(int usertype)
        {
            if (usertype == (int)UserTypeEnum.Retired)
            {
                var result= _tenderDal.GetAllByUserType(usertype);
                return result == null ? new DataResult<List<TenderListVM>>("Hata",null,true) : new DataResult<List<TenderListVM>>("Başarılı", result, true);
            }

            var tenderAllList = _tenderDal.GetAll();
            return tenderAllList!=null 
                ? new DataResult<List<TenderListVM>>("Başarılı", tenderAllList, true) 
                : new DataResult<List<TenderListVM>>("Hata", null, false);
        }

        public DataResult<List<TenderListVM>> GetAllByUserId(int userId)
        {

            var result= _tenderDal.GetAllByUserId(userId);
            if (result!=null)
            {
                return new DataResult<List<TenderListVM>>("Başarılı", result, true);
            }
            return new DataResult<List<TenderListVM>>("Hata", null, false);
        }

        public Result TenderAndDetailsAdd(TenderAndDetailsVM tenderAndDetailsVM)
        {
            throw new NotImplementedException();
        }

        public DataResult<TenderDetailListVM> GetTenderDetail(int tenderId)
        {
	        var result = _tenderDal.GetTenderDetail(tenderId);
            if (result!=null)
            {
                return new DataResult<TenderDetailListVM>("Başarılı", result, true);
            }
            return new DataResult<TenderDetailListVM>("Hata", null, false);
        }

        public DataResult<TenderOfferHistory> GetForCorporate(int tenderDetailId)
        {
	        var result = _tenderDal.GetForCorporate(tenderDetailId);
	        if (result != null)
	        {
				return new DataResult<TenderOfferHistory>("Başarılı", result, true);
			}
			return new DataResult<TenderOfferHistory>("Hata", null, false);  
        }
    }
}
