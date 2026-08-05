using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {

        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("Anyone can access");
        }


        [Authorize]
        [HttpGet("secure")]
        public IActionResult Secure()
        {
            return Ok("JWT Token is valid");
        }
    }
}