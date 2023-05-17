using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VehicleTenderCore.Core.Result;
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

        public async Task<GeneralDataType<SessionVMForUser>> CheckRetailCustomerAsync(RetailCustomerLoginVM vm)
        {
	        return await new ApiProviderBaseClass().ResultReturnPost<SessionVMForUser>(_httpClient,vm, "Login/LoginRetail","Kayıtlı Bireysel Kullanıcı Bulunamadı");
        }

        public async Task<GeneralDataType<SessionVMForUser>> CheckCorporateCustomerAsync(CorporateCustomerLoginVM vm)
        {
	        return await new ApiProviderBaseClass().ResultReturnPost<SessionVMForUser>(_httpClient,vm, "Login/LoginCorporate","Kayıtlı Kurumsal Kullanıcı Bulunamadı");
        }
    }
}
