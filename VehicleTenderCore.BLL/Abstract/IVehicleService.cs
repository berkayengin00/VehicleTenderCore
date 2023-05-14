using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.BLL.Abstract
{
    public interface IVehicleService
    {
        List<SelectListItem> GetAllVehicleByUserType(int userId);
    }
}
