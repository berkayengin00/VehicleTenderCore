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
            var result = await _httpClient.GetAsync($"Vehicle/Getall/{id}");
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<List<SelectListItem>>(await result.Content.ReadAsStringAsync());
                return new GeneralDataType<List<SelectListItem>>("", result.StatusCode, data);
            }
            return new GeneralDataType<List<SelectListItem>>("", result.StatusCode, null); ;
        }

        public async Task<GeneralDataType<VehicleDetailVM>> GetVehicleByTenderId(int vehicleId)
        {
	        var result = await _httpClient.GetAsync($"Vehicle/getByVehicleId/{vehicleId}");
	        if (result.IsSuccessStatusCode)
	        {
		        var data = JsonConvert.DeserializeObject<DataResult<VehicleDetailVM>>(await result.Content.ReadAsStringAsync());
		        return new GeneralDataType<VehicleDetailVM>(data.Message, result.StatusCode, data.Data);
	        }
	        return new GeneralDataType<VehicleDetailVM>("Hata", result.StatusCode, null); ;
        }
	}
}
