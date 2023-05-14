using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View;
using VehicleTenderCore.BLL.Abstract;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.DAL.Abstract;
using VehicleTenderCore.DAL.Context;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;

namespace VehicleTenderCore.BLL.Concrete
{
    public class TenderManager : ITenderService
    {
        private readonly ITenderDal _tenderDal;

        public TenderManager(ITenderDal tenderDal)
        {
            _tenderDal = tenderDal;
        }

        public List<TenderListVM> GetAll()
        {
            return _tenderDal.GetAll();
        }

        public List<TenderListVM> GetAllByUserType(int usertype)
        {
            if (usertype == (int)UserTypeEnum.Retired)
            {
                return _tenderDal.GetAllByUserType(usertype);
            }
            return _tenderDal.GetAll();

        }

        public void TenderAndDetailsAdd(TenderAndDetailsVM tenderAndDetailsVM)
        {
            throw new NotImplementedException();
        }
    }
}
