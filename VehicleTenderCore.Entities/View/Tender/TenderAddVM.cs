using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Enum;

namespace VehicleTenderCore.Entities.View.Tender
{
	public class TenderAddVM
	{
		[DisplayName("İhale Adı")]
		[StringLength(50, ErrorMessage = "İhale Adı 50 karakterden fazla olamaz.")]
		public string TenderName { get; set; }
		[DisplayName("İhale Durumu")]
		public int TenderStatusId { get; set; } = (int)(TenderStatusType.Baslamadi);
		[DisplayName("İhale Başlangıç Tarihi")]
		public DateTime StartDateTime { get; set; }
		[DisplayName("İhale Bitiş Tarihi")]
		public DateTime EndDateTime { get; set; }
        [DisplayName("İhale Türü")] 
        public int TenderTypeId { get; set; } = (int)UserTypeEnum.Corporate;
		public DateTime AddedDateTime { get; set; } = DateTime.Now;
		public DateTime ModefieDateTime { get; set; } = DateTime.Now;
		public int CreatedById { get; set; }
		public int UpdatedById { get; set; }
		public bool IsActive { get; set; } = true;

	}
}
