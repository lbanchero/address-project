using System.Threading.Tasks;
using AddressProject.Providers.GoogleMaps.Model;
using RestSharp;

namespace AddressProject.Providers.GoogleMaps
{
    public interface IGoogleMapsProvider
    {
        public Task<AddressInformationResponse> GetAddressInformation(string street);
    }

    public class GoogleMapsProvider
    {
        private const string API_URL = "https://maps.googleapis.com/maps/api";
        
        private const string API_KEY = "API_KEY";
        
        public async Task<AddressInformationResponse> GetAddressInformation(string street)
        {
            var url = $"{API_URL}";
            
            var client = new RestClient(url);

            var request = new RestRequest($"/geocode/json?address={street}&key={API_KEY}");
            
            return await client.GetAsync<AddressInformationResponse>(request);
        }
    }
}