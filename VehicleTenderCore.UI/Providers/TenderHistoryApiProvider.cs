using System.Collections.Generic;
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
        private readonly IApiProvider _apiProvider;
        public TenderHistoryApiProvider(HttpClient client, IApiProvider apiProvider)
        {
            _httpClient = client;
            _apiProvider = apiProvider;
        }

        public async Task<GeneralType> TenderOfferAdd(TenderOfferAddVM vm)
        {
            return await _apiProvider.ResultReturnPost(_httpClient, vm, "TenderHistory/Add", "Teklif verilemedi");
        }

        public async Task<GeneralDataType<TenderOfferHistory>> GetForCorporate(int id)
        {
	        return await _apiProvider.DataReturnGet<TenderOfferHistory>(_httpClient, "TenderDetail/GetDetailForCorporate/",id);
        }

        public async Task<GeneralDataType<List<TenderDetailAndBidVM>>> GetTenderDetailAndBid(int userId)
        {
	        return await _apiProvider.DataReturnGet<List<TenderDetailAndBidVM>>(_httpClient, "TenderHistory/GetBidsByUserId/",userId);
		}
	}
}
