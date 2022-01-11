using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;


namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantRaceAll
{
    public class GetApplicantRaceAllQueryHandler : IRequestHandler<GetApplicantRaceAllQuery, IEnumerable<Domain.Models.RaceApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantRaceAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceApplicationAnalytic>> Handle(GetApplicantRaceAllQuery request, CancellationToken cancellationToken)
        {
            var raceApplicationList = await _context.RaceApplicationAnalytic.ToListAsync();
            if (raceApplicationList == null)
                return null;

            return raceApplicationList.AsReadOnly();
        }
    }
}
