using Microsoft.AspNetCore.Http;

namespace backend_dotnet.Services
{
    public interface IEmailService
    {
        Task SendInvoiceAsync(string email, IFormFile pdf);
    }
}
