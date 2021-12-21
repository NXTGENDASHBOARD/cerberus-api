using Cerberus.Dashboard.Api.Context;
using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.ApplicationFeatures.Commands
{
    public class CreateApplicationCommand : IRequest<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string ApplicationDate { get; set; }
        public bool IsDisable { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }

        public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, int>
        {
            private readonly IApplicationService _service;

            public CreateApplicationCommandHandler(IApplicationService service)
            {
                _service = service;
            }
            public async Task<int> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
            {
                var application = new Application();

                application.Firstname = command.Firstname;
                application.Lastname = command.Lastname;
                application.Email = command.Email;
                application.Gender = command.Gender;
                application.Ethnicity = command.Ethnicity;
                application.ApplicationDate = command.ApplicationDate;
                application.IsDisable = command.IsDisable;
                application.CreateUserId = command.CreateUserId;
                application.CreatedDate = DateTime.UtcNow.ToLocalTime();
                application.ModifyUserId = command.ModifyUserId;
                application.ModifyDate = DateTime.UtcNow.ToLocalTime();
                application.IsActive = true;
                
                return  await _service.CreateApplicationAsync(application);

            }
        }
    }
}
