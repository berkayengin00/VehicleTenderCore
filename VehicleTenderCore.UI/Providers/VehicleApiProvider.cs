using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleTenderCore.Core.Result;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.Entities.View.Vehicle;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI.Providers
{
    public class VehicleApiProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IApiProvider _apiProvider;
        public VehicleApiProvider(HttpClient client,IApiProvider apiProvider)
        {
            _httpClient = client;
            _apiProvider = apiProvider;
        }

        public async Task<GeneralDataType<List<SelectListItem>>> VehicleGetAll(int id)
        {
            return await _apiProvider.DataReturnGet<List<SelectListItem>>(_httpClient, "Vehicle/Getall/", id);

        }

        public async Task<GeneralDataType<VehicleDetailVM>> GetVehicleByTenderId(int vehicleId)
        {
            return await _apiProvider.DataReturnGet<VehicleDetailVM>(_httpClient, "Vehicle/getByVehicleId/", vehicleId);
	        //var result = await _httpClient.GetAsync($"Vehicle/getByVehicleId/{vehicleId}");

         //   return await new ApiProviderBaseClass().DataReturn<VehicleDetailVM>(result);
        }
	}
}
