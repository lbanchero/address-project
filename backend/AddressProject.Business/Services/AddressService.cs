using System;
using System.Linq;
using System.Threading.Tasks;
using AddressProject.Common.DTO;
using AddressProject.Providers.GoogleMaps;

namespace AddressProject.Business.Services
{
    public class AddressService
    {
        private readonly IGoogleMapsProvider _googleMapsProvider;
        
        public AddressService(IGoogleMapsProvider googleMapsProvider)
        {
            _googleMapsProvider = googleMapsProvider;
        }

        public async Task<AddressDTO> GetAddressInformation(string streetAddress)
        {
            var result = await _googleMapsProvider.GetAddressInformation(streetAddress);

            if (result.status != "OK") throw new Exception();

            var retrievedAddress = result.results.FirstOrDefault();
            
            return new AddressDTO
            {
                Street = retrievedAddress.formatted_address,
                Longitude = retrievedAddress.geometry.location.lng,
                Latitude = retrievedAddress.geometry.location.lat
            };
        }
    }
}