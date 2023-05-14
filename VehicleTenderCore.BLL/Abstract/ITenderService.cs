using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface ITenderService
    {
        List<TenderListVM> GetAll();
        List<TenderListVM> GetAllByUserType(int usertype);
        void TenderAndDetailsAdd(TenderAndDetailsVM tenderAndDetailsVM);
    }
}
