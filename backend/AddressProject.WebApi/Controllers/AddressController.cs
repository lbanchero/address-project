using System.Threading.Tasks;
using AddressProject.Business.Services;
using AddressProject.Common.DTO;
using AddressProject.Common.Exception;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AddressProject.WebApi.Controllers
{
    [Route("api")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [Route("addresses")]
        public async Task<ActionResult<AddressDTO>> CheckAddress(AddressDTO dto)
        {
            try
            {
                return await _addressService.GetAddressInformationAsync(dto.Street);
            }
            catch (EmptyResultOnAddressProviderResponseException)
            {
                return NotFound();
            }
        }
    }
}