using System.Collections.Generic;
using System.Threading.Tasks;
using AddressProject.Business.Services;
using AddressProject.Common.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AddressProject.WebApi.Controllers
{
    [Route("api")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            return await _userService.GetAsync();
        }

        [HttpPost]
        [Route("users")]
        public async Task<ActionResult<UserDTO>> Create(UserDTO dto)
        {
            return await _userService.CreateAsync(dto);
        }
    }
}