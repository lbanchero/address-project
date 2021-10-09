using System.Threading.Tasks;
using AddressProject.Business.Services;
using AddressProject.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AddressProject.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAddressService _addressService;
        
        public UserController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<UserDTO>> Create(UserDTO dto)
        {
            return await _addressService.GetAddressInformationAsync(dto.Street);
        }
    }
}