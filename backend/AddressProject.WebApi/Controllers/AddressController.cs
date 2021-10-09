using AddressProject.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AddressProject.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpPost]
        [Route("Address")]
        public ActionResult<string> GetAddress(AddressDTO dto)
        {
            try
            {
                return "Hello World";
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}