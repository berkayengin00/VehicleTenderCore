using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private IApiProvider _apiProvider;
        public TenderDetailApiProvider(HttpClient client, IApiProvider apiProvider)
        {
            _httpClient = client;
            _apiProvider = apiProvider;
        }

        public async Task<GeneralType> TenderAndDetailAddAsync(RetailCustomerLoginVM vm)
        {
	        return await _apiProvider.ResultReturnPost(_httpClient, vm, "TenderDetail/Add");

        }

        public async Task<GeneralDataType<TenderDetailListVM>> TenderDetailsGet(int id)
        {
            return await _apiProvider.DataReturnGet<TenderDetailListVM>(_httpClient, "TenderDetail/getbyid/", id);
        }

    }
}
