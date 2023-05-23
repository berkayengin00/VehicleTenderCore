using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.BLL.JWT
{
	public class TokenHandler
	{
		public IConfiguration Configuration { get; set; }
		public TokenHandler(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		//Token üretecek metot.
		// Token üretir Geriye string token döner.
		public string GetJwtToken(SessionVMForUser vm)
		{

			//Security  Key'in simetriğini alıyoruz.
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

			//Şifrelenmiş kimliği oluşturuyoruz.
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new (JwtRegisteredClaimNames.Email, vm.Email),
				new (JwtRegisteredClaimNames.NameId, vm.UserId.ToString()),

			};

			//Oluşturulacak token ayarlarını veriyoruz.
			var expiration = DateTime.Now.AddMinutes(5);
			JwtSecurityToken securityToken = new JwtSecurityToken(
				issuer: Configuration["Token:Issuer"],
				audience: Configuration["Token:Audience"],
				expires: expiration,//Token süresini 5 dk olarak belirliyorum
				notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
				signingCredentials: signingCredentials,
				claims:claims
			);

			//Token oluşturucu sınıfında bir örnek alıyoruz.
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			//Token üretiyoruz.
			var token = tokenHandler.WriteToken(securityToken);

			//Refresh Token üretiyoruz.
			
			return token;

		}

	}
}
