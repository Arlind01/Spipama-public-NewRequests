using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Helpers
{
    public class MailService : IMailService
    {
        public async Task SendEmail(string subject, string body, List<string> recipients, List<string> attachments = null)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var smtpClient = new SmtpClient(config["Smtp:Host"])
            {
                Port = int.Parse(config["Smtp:Port"]),
                Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(config["Smtp:Username"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            foreach (var recipient in recipients)
            {
                mailMessage.To.Add(recipient);
            }

            if (attachments != null)
            {
                foreach (var item in attachments)
                {
                    var attachment = new Attachment(item, MediaTypeNames.Application.Octet);
                    mailMessage.Attachments.Add(attachment);
                }
            }

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
