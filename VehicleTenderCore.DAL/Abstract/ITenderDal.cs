﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;

namespace VehicleTenderCore.DAL.Abstract
{
    public interface ITenderDal:ICrudRepository<Tender>
    {
        List<TenderListVM> GetAll();

        List<TenderListVM> GetAllByUserType(int usertype);
        void TenderAndDetailsAdd(TenderAndDetailsVM tenderAndDetailsVM);
        TenderDetailListVM GetTenderDetail(int tenderId);

    }
}
