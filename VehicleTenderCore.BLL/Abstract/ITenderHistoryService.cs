using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View.TenderHistory;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface ITenderHistoryService
    {
        void Add(TenderOfferAddVM vm);
    }
}
