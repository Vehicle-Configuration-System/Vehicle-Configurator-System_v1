using backend_dotnet.DTO;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("user")]
    [EnableCors("FrontendPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO dto)
        {
            var message = await _userService.RegisterAsync(dto);

            if (message == "Registration Successful")
            {
                return StatusCode(201, message);
            }

            return BadRequest(message);
        }
    }
}