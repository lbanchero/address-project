using System;
using System.Linq;
using System.Threading.Tasks;
using AddressProject.Common.DTO;
using AddressProject.Providers.GoogleMaps;

namespace AddressProject.Business.Services
{
    public interface IAddressService
    {
        public Task<AddressDTO> GetAddressInformationAsync(string streetAddress);
    }

    public class AddressService : IAddressService
    {
        private readonly IGoogleMapsProvider _googleMapsProvider;
        
        public AddressService(IGoogleMapsProvider googleMapsProvider)
        {
            _googleMapsProvider = googleMapsProvider;
        }

        public async Task<AddressDTO> GetAddressInformationAsync(string streetAddress)
        {
            var result = await _googleMapsProvider.GetAddressInformationAsync(streetAddress);

            if (result.status != "OK") throw new Exception();

            var retrievedAddress = result.results.FirstOrDefault();

            if (retrievedAddress == null) throw new Exception();

            return new AddressDTO
            {
                Street = retrievedAddress.formatted_address,
                Longitude = retrievedAddress.geometry.location.lng,
                Latitude = retrievedAddress.geometry.location.lat
            };
        }
    }
}