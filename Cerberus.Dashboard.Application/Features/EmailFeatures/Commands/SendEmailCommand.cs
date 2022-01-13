using Cerberus.Dashboard.Application.Extensions.Email;
using Cerberus.Dashboard.Application.Services.Email;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.EmailFeatures.Commands
{
    public class SendEmailCommand : IRequest<int>
    {
        public List<string> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }
    }

    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, int>
    {
        private readonly IEmailService _emailService;

        public SendEmailCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<int> Handle(SendEmailCommand command, CancellationToken cancellationToken)
        {
            var emailObj = command.ToModelCommand();
            return await _emailService.SendEmailAsync(emailObj);
        }
    }

}
