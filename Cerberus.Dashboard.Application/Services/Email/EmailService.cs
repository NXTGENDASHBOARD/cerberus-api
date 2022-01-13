using Cerberus.Dashboard.Application.Constants;
using Cerberus.Dashboard.Application.ViewModels.Email;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Services.Email
{
    public interface IEmailService
    {
        Task<int> SendEmailAsync(EmailMessageViewModel model);
    }

    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration.Value;
        }

        public async Task<int> SendEmailAsync(EmailMessageViewModel model)
        {
            var emailMessage = CreateMessage(model);
            return await SendAsync(emailMessage);
        }

        private MimeMessage CreateMessage(EmailMessageViewModel model)
        {
            var emailMessage = new MimeMessage();
            var emailAddresses = new List<MailboxAddress>();

            emailAddresses.AddRange(model.To.Select(x => new MailboxAddress(address: x)));
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.EmailFrom));
            emailMessage.To.AddRange(emailAddresses);
            emailMessage.Subject = model.Subject;


            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:black;'>{0}</h2>", model.Content) };

            if (model.Attachments != null && model.Attachments.Any())
            {
                byte[] fileBytes;

                foreach (var attachment in model.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task<int> SendAsync(MimeMessage message)
        {
            int sent = 0;
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.SmtpUser, _emailConfiguration.SmtpPass);

                    client.Send(message);
                    sent++;
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException(e.Message);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }

            return sent;
        }

    }
}
