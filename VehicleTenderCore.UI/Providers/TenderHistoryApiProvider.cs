using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.TenderHistory;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI.Providers
{
    public class TenderHistoryApiProvider
    {
        private readonly HttpClient _httpClient;

        public TenderHistoryApiProvider(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GeneralType> TenderOfferAdd(TenderOfferAddVM vm)
        {
            var result = await _httpClient.PostAsync("TenderHistory/Add", new StringContent(JsonConvert.SerializeObject(vm), Encoding.UTF8, "application/json"));

            return new GeneralType(result.RequestMessage?.ToString(), result.StatusCode);
        }

        public async Task<GeneralDataType<TenderOfferHistory>> GetForCorporate(int id)
        {
	        var result = await _httpClient.GetAsync($"TenderDetail/GetDetailForCorporate/{id}");
	        if (result.IsSuccessStatusCode)
	        {
		        var data = JsonConvert.DeserializeObject<DataResult<TenderOfferHistory>>(await result.Content.ReadAsStringAsync());
		        return new GeneralDataType<TenderOfferHistory>(data.Message, result.StatusCode, data.Data);
	        }
	        return new GeneralDataType<TenderOfferHistory>("Hata", result.StatusCode, null); ;
        }
	}
}
