using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View.TenderHistory
{
	public class TenderOfferListVM
	{
		public int Id { get; set; }
		public DateTime AddedDate { get; set; }
		public decimal Price { get; set; }
	}
}
