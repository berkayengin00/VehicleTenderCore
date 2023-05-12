using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI.Providers
{
    public class LoginApiProvider
    {
        private readonly HttpClient _httpClient;
        public LoginApiProvider(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GeneralType> CheckRetailCustomerAsync(RetailCustomerLoginVM vm)
        {
            var result = await _httpClient.PostAsync("Login/LoginRetail", new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));

            var data = JsonConvert.DeserializeObject<SessionVMForUser>(await result.Content.ReadAsStringAsync());

            return new GeneralType( result.RequestMessage?.ToString(),result.StatusCode);
        }

        public async Task<GeneralType> CheckCorporateCustomerAsync(CorporateCustomerLoginVM vm)
        {
            var result = await _httpClient.PostAsync("Login/LoginCorporate", new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));

            var data = JsonConvert.DeserializeObject<SessionVMForUser>(await result.Content.ReadAsStringAsync());

            return new GeneralType(result.RequestMessage?.ToString(), result.StatusCode);
        }
    }
}
