using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VehicleTender.Entity.Concrete;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Extensions;

namespace VehicleTenderCore.UI.Providers.BaseType
{
	public class ApiProviderBaseClass:IApiProvider
	{
		private readonly IHttpContextAccessor _httpContext;
		public ApiProviderBaseClass(IHttpContextAccessor httpContext)
		{
			_httpContext = httpContext;
		}

		/// <summary>
		/// Get işlemi için kullanılır. Geriye T tipinde data döner.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="result"></param>
		/// <returns></returns>
		public async Task<GeneralDataType<T>> DataReturnGet<T>(HttpClient httpClient,string path , int id, string errorMessage = "Hata")
		{
			GetJwtToken(httpClient);
			var result = await httpClient.GetAsync(path+id);

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
		public async Task<GeneralType> ResultReturnPost(HttpClient httpClient,object vm,string path,string errorMessage="Hata")
		{
			GetJwtToken(httpClient);
			var result = await httpClient.PostAsync(path, new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));
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
		public async Task<GeneralDataType<T>> ResultReturnPost<T>(HttpClient httpClient, object vm, string path, string errorMessage = "Hata")
		{
			
			var result = await httpClient.PostAsync(path, new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));
			if (result.IsSuccessStatusCode)
			{
				var data = JsonConvert.DeserializeObject<DataResult<T>>(await result.Content.ReadAsStringAsync());
				return new GeneralDataType<T>(data.Message, result.StatusCode, data.Data);
			}
			return new GeneralDataType<T>(errorMessage, result.StatusCode);
		}

		public void GetJwtToken(HttpClient httpClient)
		{
			var token = _httpContext.HttpContext.Session.MySessionGet<SessionVMForUser>("user").Token;
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}
	}
}
