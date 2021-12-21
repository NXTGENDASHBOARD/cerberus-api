using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.UpdateInstitution
{
    public class UpdateInstitutionCommandHandler : IRequestHandler<UpdateInstitutionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateInstitutionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateInstitutionCommand command, CancellationToken cancellationToken)
        {
            var institutionToUpdate = await _context.Institutions.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (institutionToUpdate == null) return default;

            institutionToUpdate.Name = command.Name;
            institutionToUpdate.Region = command.Region;
            institutionToUpdate.IsMainCampus = command.IsMainCampus;
            institutionToUpdate.Province = command.Province;
            institutionToUpdate.PostCode = command.PostCode;
            institutionToUpdate.ModifyDate = DateTime.UtcNow.ToLocalTime();
            institutionToUpdate.ModifyUserId = command.ModifyUserId;
            institutionToUpdate.IsActive = command.IsActive;
            institutionToUpdate.StatusId = command.StatusId;

            _context.Institutions.Update(institutionToUpdate);
            await _context.SaveChangesAsync();
            return institutionToUpdate.Id;
        }
    }
}
