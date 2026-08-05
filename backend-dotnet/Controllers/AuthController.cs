using backend_dotnet.DTOs;
using backend_dotnet.Services;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using backend_dotnet.DTOs;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequestDto request)
        {

            await _authService.Register(request);

            return Ok(new
            {
                message = "Registration successful"
            });
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequestDto request)
        {

            var response =
                await _authService.Login(request);


            return Ok(response);
        }

    }
}