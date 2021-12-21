using Cerberus.Dashboard.Api.Context;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.ApplicationFeatures.Commands
{
    public class UpdateApplicationCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string ApplicationDate { get; set; }
        public bool IsDisable { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; }

        public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, int>
        {
            private readonly IApplicationService _service;

            public UpdateApplicationCommandHandler(IApplicationService service)
            {
                _service = service;
            }
            public async Task<int> Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
            {
                var applicationToUpdate = await _service.GetApplicationByIdAsync(command.Id);
                if (applicationToUpdate == null)
                {
                    return default;
                }
                else
                {
                    applicationToUpdate.Firstname = command.Firstname;
                    applicationToUpdate.Lastname = command.Lastname;
                    applicationToUpdate.Email = command.Email;
                    applicationToUpdate.Gender = command.Gender;
                    applicationToUpdate.Ethnicity = command.Ethnicity;
                    applicationToUpdate.ApplicationDate = command.ApplicationDate;
                    applicationToUpdate.IsDisable = command.IsDisable;
                    applicationToUpdate.ModifyUserId = command.ModifyUserId;
                    applicationToUpdate.ModifyDate = DateTime.UtcNow.ToLocalTime();
                    applicationToUpdate.IsActive = command.IsActive;
                    return await _service.UpdateApplicationAsync(applicationToUpdate);
                }

            }
        }

    }
}
