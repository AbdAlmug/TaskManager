using System.Net;
using System.Net.Mail;

namespace TaskManager.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var from = _configuration["EmailSettings:From"];
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(_configuration["EmailSettings:Port"]!);
            var username = _configuration["EmailSettings:Username"];
            var password = _configuration["EmailSettings:Password"];

            var message = new MailMessage(from!, toEmail, subject, body);
            message.IsBodyHtml = true;

            // Run SendMailAsync in its own task so it isn't tied to the request cancellation
            return Task.Run(async () =>
            {
                using var client = new SmtpClient(smtpServer, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };

                await client.SendMailAsync(message);
            });
        }
    }
}
