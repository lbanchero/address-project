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

        [HttpGet]
        [Route("addresses")]
        public async Task<ActionResult<AddressDTO>> GetAddress(AddressDTO dto)
        {
            return await _addressService.GetAddressInformationAsync(dto.Street);
        }
    }
}