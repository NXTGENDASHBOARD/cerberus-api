using Cerberus.Dashboard.Application.Features.EmailFeatures.Commands;
using Cerberus.Dashboard.Application.ViewModels.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions.Email
{
    public static class EmailExtensions
    {
        public static EmailMessageViewModel ToModelCommand(this SendEmailCommand model)
        {
            return new EmailMessageViewModel
            {
                To = model.To,
                Subject = model.Subject,
                Content = model.Content,
                Attachments = model.Attachments,
            };
        }

        public static EmailMessageViewModel ToModelCommand(this SendOtpEmailCommand model)
        {
            return new EmailMessageViewModel
            {
                To = model.To,
                Subject = model.Subject,
                Content = model.Content,
            };
        }
    }
}
