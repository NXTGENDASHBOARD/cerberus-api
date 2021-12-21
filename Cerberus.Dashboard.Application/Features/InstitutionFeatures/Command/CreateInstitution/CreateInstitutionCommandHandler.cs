using Cerberus.Dashboard.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.CreateInstitution
{
    public class CreateInstitutionCommandHandler : IRequestHandler<CreateInstitutionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInstitutionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateInstitutionCommand command, CancellationToken cancellationToken)
        {
            var institution = new Institution();

            institution.Name = command.Name;
            institution.Region = command.Region;
            institution.IsMainCampus = command.IsMainCampus;
            institution.Province = command.Province;
            institution.PostCode = command.PostCode;
            institution.CreateUserId = command.CreateUserId;
            institution.CreatedDate = DateTime.UtcNow.ToLocalTime();
            institution.ModifyUserId = command.ModifyUserId;
            institution.ModifyDate = DateTime.UtcNow.ToLocalTime();
            institution.IsActive = command.IsActive;
            institution.StatusId = command.StatusId;

            _context.Institutions.Add(institution);
            await _context.SaveChangesAsync();
            return institution.Id;
        }
    }
}
