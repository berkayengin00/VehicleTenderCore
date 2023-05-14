using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.Entities.View.Tender;
using VehicleTenderCore.UI.Providers.BaseType;

namespace VehicleTenderCore.UI.Providers
{
    public class TenderApiProvider
    {
        private readonly HttpClient _httpClient;

        public TenderApiProvider(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GeneralDataType<List<TenderListVM>>> TenderGetAll(int id)
        {
            var result = await _httpClient.GetAsync($"Tender/GetAll/{id}");
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<List<TenderListVM>>(await result.Content.ReadAsStringAsync());
                return new GeneralDataType<List<TenderListVM>>("", result.StatusCode, data);
            }
            return new GeneralDataType<List<TenderListVM>>("", result.StatusCode, null); ;
        }


	}
}
