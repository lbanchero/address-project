using System;
using System.Threading.Tasks;
using AddressProject.Common.Exception;
using AddressProject.Providers.GoogleMaps.Model;
using RestSharp;

namespace AddressProject.Providers.GoogleMaps
{
    public interface IAddressProvider
    {
        public Task<AddressInformationResponse> GetAddressInformationAsync(string street);
    }

    public class AddressProvider : IAddressProvider
    {
        private const string API_URL = "https://maps.googleapis.com/maps/api";
        
        private const string API_KEY = "AIzaSyDyo3C2rZVouan7-1MzC-xR378mmhIQJw8";
        
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