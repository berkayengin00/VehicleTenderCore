using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.TenderDetail;
using VehicleTenderCore.Entities.View.TenderHistory;
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

        public async Task<GeneralDataType<TenderDetailListVM>> TenderDetailsGet(int id)
        {
	        var result = await _httpClient.GetAsync($"TenderDetail/getbyid/{id}");
	        if (result.IsSuccessStatusCode)
	        {
		        var data = JsonConvert.DeserializeObject<DataResult<TenderDetailListVM>>(await result.Content.ReadAsStringAsync());
		        return new GeneralDataType<TenderDetailListVM>(data.Message, result.StatusCode, data.Data);
	        }
	        return new GeneralDataType<TenderDetailListVM>("", result.StatusCode, null); ;
        }


	}
}
