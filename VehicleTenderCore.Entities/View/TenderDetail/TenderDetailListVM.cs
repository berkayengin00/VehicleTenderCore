using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View.TenderDetail
{
	public class TenderDetailListVM
	{
		public int TenderId { get; set; }
		[DisplayName("İhale Adı")]
		public string TenderName { get; set; }
		[DisplayName("İhale Durumu")]
		public int TenderStatusId { get; set; }
		public string TenderStatusName { get; set; }
		[DisplayName("İhale Başlangıç Tarihi")]
		public DateTime StartDateTime { get; set; }
		[DisplayName("İhale Bitiş Tarihi")]
		public DateTime EndDateTime { get; set; }
		[DisplayName("İhale Türü")]
		public int TenderTypeId { get; set; }

		public List<TenderAndVehicleDetailVM> TenderAndVehicleDetailList{ get; set; }
		public List<SelectListItem> TenderTypes { get; set; }
	}
}
