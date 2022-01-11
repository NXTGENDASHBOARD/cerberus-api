using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantFeederSchoolsAll
{
    public class GetApplicantFeederSchoolsAllQueryHandler : IRequestHandler<GetApplicantFeederSchoolsAllQuery, IEnumerable<Domain.Models.FeederSchoolApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantFeederSchoolsAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeederSchoolApplicationAnalytic>> Handle(GetApplicantFeederSchoolsAllQuery request, CancellationToken cancellationToken)
        {
            var feederSchoolApplicationList = await _context.FeederSchoolApplicationAnalytic.ToListAsync();
            if (feederSchoolApplicationList == null)
                return null;

            return feederSchoolApplicationList.AsReadOnly();
        }
    }
}
