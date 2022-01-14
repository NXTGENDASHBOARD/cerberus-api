using Cerberus.Dashboard.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetFacultiesByInstitutionId
{
    public class GetFacultiesByInstitutionIdQueryHandler : IRequestHandler<GetFacultiesByInstitutionIdQuery, IEnumerable<Faculty>>
    {
        private readonly IApplicationDbContext _context;

        public GetFacultiesByInstitutionIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Faculty>> Handle(GetFacultiesByInstitutionIdQuery query, CancellationToken cancellationToken)
        {
            var faculties = await _context.Faculty.Where(x => x.InstitutionId == query.Id).ToListAsync();
            if (faculties == null) return null;
            return faculties.AsReadOnly();
        }

    }
}
