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

        public TenderDetailApiProvider(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GeneralType> TenderAndDetailAddAsync(RetailCustomerLoginVM vm)
        {
	        return await new ApiProviderBaseClass().ResultReturnPost(_httpClient, vm, "TenderDetail/Add");

        }

        public async Task<GeneralDataType<TenderDetailListVM>> TenderDetailsGet(int id)
        {
            return await new ApiProviderBaseClass().DataReturnGet<TenderDetailListVM>(_httpClient, "TenderDetail/getbyid/", id);
        }

    }
}
