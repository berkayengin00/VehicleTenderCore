using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.RetailCustomer;
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

        public async Task<GeneralType> RegisterAsync(RetailCustomerRegisterVM vm)
        {
            var result = await _httpClient.PostAsync("RetailCustomer/Register", new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));

            return new GeneralType(result.RequestMessage?.ToString(), result.StatusCode);
        }
    }
}
