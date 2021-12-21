using Cerberus.Dashboard.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.InstitutionFeatures.Queries.GetInstitutionById
{
    public class GetInstitutionByIdQueryHandler : IRequestHandler<GetInstitutionByIdQuery, Institution>
    {
        private readonly IApplicationDbContext _context;

        public GetInstitutionByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Institution> Handle(GetInstitutionByIdQuery query, CancellationToken cancellationToken)
        {
            var institution = await _context.Institutions.FirstOrDefaultAsync(x => x.Id == query.Id);
            if (institution == null) return default;
            return institution;
        }
    }
}
