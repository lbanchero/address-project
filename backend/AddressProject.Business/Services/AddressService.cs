using System.Linq;
using System.Threading.Tasks;
using AddressProject.Common.DTO;
using AddressProject.Common.Exception;
using AddressProject.Providers.GoogleMaps;

namespace AddressProject.Business.Services
{
    public interface IAddressService
    {
        public Task<AddressDTO> GetAddressInformationAsync(string streetAddress);
    }

    public class AddressService : IAddressService
    {
        private readonly IAddressProvider _addressProvider;
        
        public AddressService(IAddressProvider addressProvider)
        {
            _addressProvider = addressProvider;
        }

        public async Task<AddressDTO> GetAddressInformationAsync(string streetAddress)
        {
            var addressInformationResponse = await _addressProvider.GetAddressInformationAsync(streetAddress);
            
            if (addressInformationResponse.status == "ZERO_RESULTS")
                throw new EmptyResultOnAddressProviderResponseException();

            if (addressInformationResponse.status != "OK")
                throw new AddressProviderUnsuccessfulResponseException();

            var retrievedAddress = addressInformationResponse.results.First();

            return new AddressDTO
            {
                Street = retrievedAddress.formatted_address,
                Longitude = retrievedAddress.geometry.location.lng,
                Latitude = retrievedAddress.geometry.location.lat
            };
        }
    }
}