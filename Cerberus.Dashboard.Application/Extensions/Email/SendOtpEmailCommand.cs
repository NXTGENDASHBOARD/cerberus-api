using Cerberus.Dashboard.Application.Services.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions.Email
{
    public class SendOtpEmailCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string OtpCode { get; set; }
        public string Origin { get; set; }
        public List<string> To { get; set; }

        public string Subject { get; set; } = "OTP Verification | ITS 5.0 Student Selection";

        public string Content { get; set; }

    }

    public class SendOtpEmailCommandHandler : IRequestHandler<SendOtpEmailCommand, int>
    {
        private readonly IEmailService _emailService;

        public SendOtpEmailCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<int> Handle(SendOtpEmailCommand command, CancellationToken cancellationToken)
        {
            var message = $@"<h5>Please use the OTP below to verify your account with our system.</h5>
                            <p>OTP: {command.OtpCode}</p>";

            var link = @"";
            var verifyUrl = $"{command.Origin}/verify";
            link = $@"<h5>Please click the below link to verify your account:</h5>
                             <h5><a href=""{verifyUrl}"">{verifyUrl}</a></h5>";


            command.Content = $@"<h4>Hello, {command.FullName}</h4>
                                 {message} {link}
                                <h5>Thank you : Support Team ©2022 ITS 5.0 Student Selection</h5>
                                ";

            var emailObj = command.ToModelCommand();
            return await _emailService.SendEmailAsync(emailObj);

        }
 
    }

}
