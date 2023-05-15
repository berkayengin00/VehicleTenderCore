using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View.TenderHistory
{
    public class TenderOfferHistory
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
        public decimal TenderMinPrice { get; set; }

        public List<TenderOfferListVM> TenderOfferList { get; set; }
        
    }
}
