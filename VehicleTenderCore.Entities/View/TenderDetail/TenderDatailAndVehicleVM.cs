using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View.TenderDetail
{
	public class TenderAndVehicleDetailVM
	{
		public int TenderDetailId { get; set; }
		public string LicencePlate { get; set; }
		public decimal MinPrice { get; set; }
		public decimal StartPrice { get; set; }
		public List<string> VehicleImages { get; set; }
	}
}
