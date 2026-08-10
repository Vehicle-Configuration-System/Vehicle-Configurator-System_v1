using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace EmailService.Services
{
    public class EmailServices : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendInvoiceAsync(string email, IFormFile pdf)
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:Email"]));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "Vehicle Configuration Invoice";

            var builder = new BodyBuilder();

            builder.TextBody =
                "Dear Customer,\n\n" +
                "Please find attached your Vehicle Configuration Invoice.\n\n" +
                "Thank You.";

            using var stream = pdf.OpenReadStream();

            builder.Attachments.Add(
                "Invoice.pdf",
                stream,
                ContentType.Parse("application/pdf"));

            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _configuration["EmailSettings:Host"],
                int.Parse(_configuration["EmailSettings:Port"]),
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _configuration["EmailSettings:Email"],
                _configuration["EmailSettings:Password"]);

            await smtp.SendAsync(message);

            await smtp.DisconnectAsync(true);
        }
    }
}