using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI.Providers
{
    public class RetailCustomerApiProvider
    {
        private readonly HttpClient _httpClient;
        public RetailCustomerApiProvider(HttpClient client)
        {
            _httpClient = client;
        }   

        public async Task<GeneralType> CheckRetailCustomerAsync(RetailCustomerLoginVM vm)
        {
            var result = await _httpClient.PostAsync("Login/LoginRetail", new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));

            var data = JsonConvert.DeserializeObject<SessionVMForUser>(await result.Content.ReadAsStringAsync());

            return new GeneralType(result.RequestMessage?.ToString(), result.StatusCode);
        }
    }
}
