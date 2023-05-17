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
            return await new ApiProviderBaseClass().ResultReturnPost(_httpClient, vm, "TenderHistory/Add", "Teklif verilemedi");
        }

        public async Task<GeneralDataType<TenderOfferHistory>> GetForCorporate(int id)
        {
	        return await new ApiProviderBaseClass().DataReturnGet<TenderOfferHistory>(_httpClient, "TenderDetail/GetDetailForCorporate/",id);
        }
	}
}
