using System.Threading.Tasks;
using AddressProject.Business.Services;
using AddressProject.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AddressProject.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [Route("address")]
        public async Task<ActionResult<AddressDTO>> GetAddress(AddressDTO dto)
        {
            try
            {
                return await _addressService.GetAddressInformationAsync(dto.Street);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}