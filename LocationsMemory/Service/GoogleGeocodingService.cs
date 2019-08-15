using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using LocationsMemory.APIs;
using LocationsMemory.Core;
using LocationsMemory.Data;
using Newtonsoft.Json;
using static LocationsMemory.APIs.GoogleGeoecodingApi;

namespace LocationsMemory.Service
{
    public class GoogleGeocodingService
    {
        public HttpClient Client { get; }

            public GoogleGeocodingService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://maps.googleapis.com");

            Client = client;
        }

        public async Task<string> GoogleApiDingens(Core.Location location)
        {
            try
            {
                var response = await Client.GetAsync($"/maps/api/geocode/json?address={location.Street_number}+{location.Street_name}+{location.City}+&key=AIzaSyB_0wHwmbg5aMjbUxMvT3SxjlE_aSnYlp4");

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                GoogleGeoecodingApi obj = JsonConvert.DeserializeObject<GoogleGeoecodingApi>(result);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
            

            
        }
    }
}
