using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.DAL.Abstract
{
    public interface ITenderDal:ICrudRepository<Tender>
    {
        List<TenderListVM> GetAll();
        List<TenderListVM> GetAllByUserType(int usertype);
        void TenderAndDetailsAdd(TenderAndDetailsVM tenderAndDetailsVM);
        TenderDetailListVM GetTenderDetail(int tenderId);
        List<TenderListVM> GetAllByUserId(int userId);
		TenderOfferHistory GetForCorporate(int tenderDetailId);
	}
}
