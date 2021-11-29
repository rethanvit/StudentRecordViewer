using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace StudentRecordViewerApp.Areas.Identity
{
    public class EmailSender : IEmailSender
    {
        private string _apiKey;
        private string _fromName;
        private string _fromEmail;

        public EmailSender(IConfiguration config)
        {
            _apiKey = config["SendGrid:ApiKey"];
            _fromName = config["SendGrid:FromName"];
            _fromEmail = config["SendGrid:FromEmail"];
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var mail = new SendGridMessage
            {
                From = new EmailAddress(_fromEmail, _fromName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            mail.AddTo(new EmailAddress(email));
            mail.SetClickTracking(false, false);

            await client.SendEmailAsync(mail);
        }
    }
}
