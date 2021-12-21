using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.UpdateApplication
{
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateApplicationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
        {
            var applicationToUpdate = await _context.Applications.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (applicationToUpdate == null) return default;
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
            applicationToUpdate.StatusId = command.StatusId;

            _context.Applications.Update(applicationToUpdate);
            await _context.SaveChangesAsync();
            return applicationToUpdate.Id;
        }
    }
}
