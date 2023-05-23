using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Entities.View
{
	public class TokenUserVM
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RefreshToken { get; set; }
		public DateTime? RefreshTokenEndDate { get; set; }
	}
}
