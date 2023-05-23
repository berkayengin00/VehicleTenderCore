using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.DataAccess.Repository;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.DAL.Abstract
{
    public interface ITenderHistoryDal:ICrudRepository<TenderHistory>
    {
	    List<TenderDetailAndBidVM> GetTenderDetailAndBid(int userId);
	    void Test2();

    }
}
