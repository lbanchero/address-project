using System;
using System.Threading.Tasks;
using AddressProject.Common.Exception;
using AddressProject.Providers.GoogleMaps.Model;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace AddressProject.Providers.GoogleMaps
{
    public interface IAddressProvider
    {
        public Task<AddressInformationResponse> GetAddressInformationAsync(string street);
    }

    public class AddressProvider : IAddressProvider
    {
        private readonly string API_URL;
        
        private readonly string API_KEY;

        public AddressProvider(IConfiguration config)
        {
            API_URL = config["GoogleMapsAPIUrl"];
            API_KEY = config["GoogleMapsApiKey"];
        }

        public async Task<AddressInformationResponse> GetAddressInformationAsync(string street)
        {
            try
            {
                var client = new RestClient(API_URL);

                var request = new RestRequest($"/geocode/json")
                    .AddParameter("address", street)
                    .AddParameter("key", API_KEY);
            
                return await client.GetAsync<AddressInformationResponse>(request);
            }
            catch (Exception ex)
            {
                throw new AddressProviderCommunicationException(ex);
            }
        }
    }
}