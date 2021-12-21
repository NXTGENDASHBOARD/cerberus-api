using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.CreateApplication
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateApplicationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var application = new Domain.Models.Application();
           
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
            application.StatusId = command.StatusId;

            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application.Id;
        }
    }
}
