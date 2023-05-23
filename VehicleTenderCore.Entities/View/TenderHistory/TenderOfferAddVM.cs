using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VehicleTenderCore.Entities.View.TenderHistory
{
    public class TenderOfferAddVM
    {
	    public int TenderId { get; set; }
        public int TenderDetailId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime AddedDate { get; set; }=DateTime.Now;
    }
}
