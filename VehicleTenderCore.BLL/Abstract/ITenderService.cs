using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Tender;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface ITenderService
    {
        DataResult<List<TenderListVM>> GetAll();
        DataResult<List<TenderListVM>> GetAllByUserType(int usertype);
        DataResult<List<TenderListVM>> GetAllByUserId(int userId);
        Result TenderAndDetailsAdd(TenderAndDetailsVM tenderAndDetailsVM);
        DataResult<TenderDetailListVM> GetTenderDetail(int tenderId);
        DataResult<TenderOfferHistory> GetForCorporate(int tenderDetailId);
    }
}
