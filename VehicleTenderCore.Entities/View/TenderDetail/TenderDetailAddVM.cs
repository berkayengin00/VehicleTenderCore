using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VehicleTenderCore.Entities.View.TenderDetail
{
	public class TenderDetailAddVM
	{
		public int TenderId { get; set; }
		public int VehicleId { get; set; }
		public decimal MinPrice { get; set; }
		public decimal StartPrice { get; set; }

		public List<SelectListItem> Vehicles { get; set; }
	}
}
