using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;

namespace VehicleTenderCore.Entities.View
{
	public class TenderAndDetailsVM
	{
		public TenderAddVM TenderAddVM { get; set; }	
		public List<TenderDetailAddVM> TenderDetailAddVM { get; set; }
	}

}
