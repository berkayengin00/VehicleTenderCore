using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.TenderDetail;

namespace VehicleTenderCore.Entities.View.TenderHistory
{
	public class TenderDetailAndBidVM
	{
		public int TenderId { get; set; }

		[DisplayName("İhale Adı")]
		public string TenderName { get; set; }
		[DisplayName("İhale Durumu")]
		public string TenderStatusName { get; set; }
		[DisplayName("İhale Başlangıç Tarihi")]
		public DateTime StartDateTime { get; set; }
		[DisplayName("İhale Bitiş Tarihi")]
		public DateTime EndDateTime { get; set; }
		public int TenderType { get; set; }

		public List<TenderDetailForTenderOffer> TenderDetailForTenderOffers { get; set; }

	}

	public class TenderDetailForTenderOffer
	{
		public int TenderDetailId { get; set; }
		[DisplayName("Araç Plaka")]
		public string LicensePlate { get; set; }
		[DisplayName("Marka")]
		public string Brand { get; set; }
		[DisplayName("Model")]
		public string Model { get; set; }
		public List<TenderBidVM> TenderBidList { get; set; }
	}
	public class TenderBidVM
	{
		[DisplayName("Teklif Edilen Fiyat")]
		public decimal Price { get; set; }
		[DisplayName("Teklif Verilme Zamanı")]
		public DateTime AddedDate { get; set; }

	}
}
