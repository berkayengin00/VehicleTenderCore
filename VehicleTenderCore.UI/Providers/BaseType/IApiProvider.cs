using System.Net.Http;
using System.Threading.Tasks;

namespace VehicleTenderCore.UI.Providers.BaseType
{
	public interface IApiProvider
	{
		Task<GeneralDataType<T>> DataReturnGet<T>(HttpClient httpClient, string path, int id, string errorMessage = "Hata");

		Task<GeneralType> ResultReturnPost(HttpClient httpClient, object vm, string path, string errorMessage = "Hata");

		Task<GeneralDataType<T>> ResultReturnPost<T>(HttpClient httpClient, object vm, string path, string errorMessage = "Hata");
	}
}
