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
        public VehicleApiProvider(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GeneralDataType<List<SelectListItem>>> VehicleGetAll(int id)
        {
            return await new ApiProviderBaseClass().DataReturnGet<List<SelectListItem>>(_httpClient, "Vehicle/Getall/", id);

        }

        public async Task<GeneralDataType<VehicleDetailVM>> GetVehicleByTenderId(int vehicleId)
        {
            return await new ApiProviderBaseClass().DataReturnGet<VehicleDetailVM>(_httpClient, "Vehicle/getByVehicleId/", vehicleId);
	        //var result = await _httpClient.GetAsync($"Vehicle/getByVehicleId/{vehicleId}");

         //   return await new ApiProviderBaseClass().DataReturn<VehicleDetailVM>(result);
        }
	}
}
