using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI.Providers
{
    public class TenderDetailApiProvider
    {
        private readonly HttpClient _httpClient;

        public TenderDetailApiProvider(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GeneralType> TenderAndDetailAddAsync(RetailCustomerLoginVM vm)
        {
            var result = await _httpClient.PostAsync("TenderDetail/Add", new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));

            return new GeneralType(result.RequestMessage?.ToString(), result.StatusCode);
        }
    }
}
