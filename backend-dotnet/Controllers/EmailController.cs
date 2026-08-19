using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(
            [FromForm] string email,
            [FromForm] IFormFile pdf)
        {
            await _emailService.SendInvoiceAsync(email, pdf);

            return Ok("Email Sent Successfully");
        }
    }
}