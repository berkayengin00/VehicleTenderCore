using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface ITenderHistoryService
    {
        Result Add(TenderOfferAddVM vm);
        DataResult<List<TenderDetailAndBidVM>> GetTenderDetailAndBid(int userId);
    }
}
