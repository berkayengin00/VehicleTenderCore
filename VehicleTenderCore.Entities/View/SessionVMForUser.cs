using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;

namespace VehicleTenderCore.Entities.View
{
    public class SessionVMForUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
    }
}
