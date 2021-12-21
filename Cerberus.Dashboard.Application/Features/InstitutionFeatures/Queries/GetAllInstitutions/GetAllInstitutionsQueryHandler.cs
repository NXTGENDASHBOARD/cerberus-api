using Cerberus.Dashboard.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetAllInstitutions
{
    public class GetAllInstitutionsQueryHandler : IRequestHandler<GetAllInstitutionsQuery, IEnumerable<Institution>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllInstitutionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Institution>> Handle(GetAllInstitutionsQuery request, CancellationToken cancellationToken)
        {
            var institutionList = await _context.Institutions.ToListAsync();
            if (institutionList == null) return null;
            return institutionList.AsReadOnly();
        }
    }
}
