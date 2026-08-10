using Microsoft.AspNetCore.Http;

namespace EmailService.Services
{
    public interface IEmailService
    {
        Task SendInvoiceAsync(string email, IFormFile pdf);
    }
}