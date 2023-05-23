using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View.Vehicle
{
	public class VehicleDetailVM
	{
		
		[DisplayName("Plaka")]
		public string LicensePlate { get; set; }
		[DisplayName("Model Yılı")]
		public short VehicleYear { get; set; }
		[DisplayName("Versiyon")]
		public string Version { get; set; }
		[DisplayName("Kilometre")]
		public int KiloMeter { get; set; }
		[DisplayName("Açıklama")]
		public string Description { get; set; }
		[DisplayName("Vites Tipi")]
		public string GearTypeName { get; set; }
		[DisplayName("Yakıt Tipi")]
		public string FuelTypeName { get; set; }
		[DisplayName("Kasa Tipi")]
		public string BodyTypeName { get; set; }
		[DisplayName("Model")]
		public string ModelName { get; set; }
		[DisplayName("Renk")]
		public string ColorName { get; set; }
		[DisplayName("Marka")]
		public string BrandName { get; set; }
	}
}
