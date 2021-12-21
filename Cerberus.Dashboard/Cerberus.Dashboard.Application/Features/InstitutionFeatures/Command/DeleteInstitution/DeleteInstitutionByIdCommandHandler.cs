using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Command.DeleteInstitution
{
    public class DeleteInstitutionByIdCommandHandler : IRequestHandler<DeleteInstitutionByIdCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteInstitutionByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteInstitutionByIdCommand command, CancellationToken cancellationToken)
        {
            var institutionToDelete = await _context.Institutions.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (institutionToDelete == null) return default;

            _context.Institutions.Remove(institutionToDelete);
            await _context.SaveChangesAsync();
            return institutionToDelete.Id;
        }
    }
}
