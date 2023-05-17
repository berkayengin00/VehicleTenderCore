using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VehicleTenderCore.Core.Result;

namespace VehicleTenderCore.UI.Providers.BaseType
{
	public class ApiProviderBaseClass
	{
		/// <summary>
		/// Parametre olarak apiden gelen HttpResponseMessage alır ve status koduna göre içerisindeki datayı döner.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task<GeneralDataType<T>> DataReturn<T>(HttpResponseMessage result)
		{
			var data = JsonConvert.DeserializeObject<DataResult<T>>(await result.Content.ReadAsStringAsync());
			if (result.IsSuccessStatusCode)
			{
				return new GeneralDataType<T>(data.Message, result.StatusCode, data.Data);
			}
			return new GeneralDataType<T>("Sistemde Kayıtlı Kullanıcı Bulunamadı", result.StatusCode);
		}

		/// <summary>
		/// Parametre olarak apiden gelen HttpResponseMessage alır ve status koduna göre içerisindeki mesajı döner.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task<GeneralType> ResultReturn(HttpResponseMessage result)
		{
			if (result.IsSuccessStatusCode)
			{
				var data = JsonConvert.DeserializeObject<Result>(await result.Content.ReadAsStringAsync());
				return new GeneralType(data.Message, result.StatusCode);
			}
			return new GeneralType("Sistemde Kayıtlı Kullanıcı Bulunamadı", result.StatusCode);
		}
	}
}
