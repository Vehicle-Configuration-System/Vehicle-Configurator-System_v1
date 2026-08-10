using System.Net.Http.Headers;

namespace backend_dotnet.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendInvoiceAsync(string email, IFormFile pdf)
        {
            using var formData = new MultipartFormDataContent();

            formData.Add(
                new StringContent(email),
                "email");

            using var stream = pdf.OpenReadStream();

            var fileContent = new StreamContent(stream);

            fileContent.Headers.ContentType =
                new MediaTypeHeaderValue("application/pdf");

            formData.Add(
                fileContent,
                "pdf",
                "Invoice.pdf");

            await _httpClient.PostAsync(
                "api/email/send",
                formData);
        }
    }
}