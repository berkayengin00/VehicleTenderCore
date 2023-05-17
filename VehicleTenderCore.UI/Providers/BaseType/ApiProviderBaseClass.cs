using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.Result;

namespace VehicleTenderCore.UI.Providers.BaseType
{
	public class ApiProviderBaseClass
	{

		/// <summary>
		/// Get işlemi için kullanılır. Geriye T tipinde data döner.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task<GeneralDataType<T>> DataReturnGet<T>(HttpClient _httpClient,string path , int id, string errorMessage = "Hata")
		{
			var result = await _httpClient.GetAsync(path+id);

			if (result.IsSuccessStatusCode)
			{
				var data = JsonConvert.DeserializeObject<DataResult<T>>(await result.Content.ReadAsStringAsync());
				return new GeneralDataType<T>(data.Message, result.StatusCode, data.Data);
			}
			return new GeneralDataType<T>(errorMessage, result.StatusCode);
		}


		/// <summary>
		/// Post işlemi için kullanılır.
		/// Geriye GeneralType ( mesaj ve HttpStatusCode) döner.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task<GeneralType> ResultReturnPost(HttpClient _httpClient,object vm,string path,string errorMessage="Hata")
		{
			var result = await _httpClient.PostAsync(path, new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));
			if (result.IsSuccessStatusCode)
			{
				var data = JsonConvert.DeserializeObject<Result>(await result.Content.ReadAsStringAsync());
				return new GeneralType(data.Message, result.StatusCode);
			}
			return new GeneralType(errorMessage, result.StatusCode);
		}


		/// <summary>
		/// Post işlemi için kullanılır. Geriye GeneralDataType<T> tipinde bir data döner.
		/// 
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task<GeneralDataType<T>> ResultReturnPost<T>(HttpClient _httpClient, object vm, string path, string errorMessage = "Hata")
		{
			var result = await _httpClient.PostAsync(path, new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));
			if (result.IsSuccessStatusCode)
			{
				var data = JsonConvert.DeserializeObject<DataResult<T>>(await result.Content.ReadAsStringAsync());
				return new GeneralDataType<T>(data.Message, result.StatusCode, data.Data);
			}
			return new GeneralDataType<T>(errorMessage, result.StatusCode);
		}
	}
}
