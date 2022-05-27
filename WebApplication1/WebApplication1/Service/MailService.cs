using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebApplication1.Model;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service
{
    public class MailService : IMailService
    {
        private readonly MailConfig _mailConfig;
        private readonly IConfiguration _configuration;
        public MailService(IOptions<MailConfig> emailConfig, IConfiguration configuration)
        {
            _mailConfig = emailConfig.Value;
            _configuration = configuration;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var apiKey = _configuration.GetSection("Sendgrid").GetSection("ApiKey").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_mailConfig.FromAddress, _mailConfig.FromName);
            var subject = mailRequest.Subject;
            var to = new EmailAddress(mailRequest.ToEmail, mailRequest.ToName);
            var plainTextContent = "";
            var htmlContent = "<html><body> " + mailRequest.Body + " </body></html>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
