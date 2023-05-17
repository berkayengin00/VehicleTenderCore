using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTenderCore.Core.Result;
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
            return await new ApiProviderBaseClass().DataReturnGet<List<TenderListVM>>(_httpClient, "Tender/GetAll/",id);
   //         var result = await _httpClient.GetAsync($"Tender/GetAll/{id}");

			//return await new ApiProviderBaseClass().DataReturn<List<TenderListVM>>(result);
        }

        public async Task<GeneralDataType<List<TenderListVM>>> TenderGetAllByUserId(int id)
        {
            return await new ApiProviderBaseClass().DataReturnGet<List<TenderListVM>>(_httpClient, "Tender/GetAllByUserId/", id);
            //var result = await _httpClient.GetAsync($"Tender/GetAllByUserId/{id}");

            //return await new ApiProviderBaseClass().DataReturn<List<TenderListVM>>(result);
			
        }

    }
}
