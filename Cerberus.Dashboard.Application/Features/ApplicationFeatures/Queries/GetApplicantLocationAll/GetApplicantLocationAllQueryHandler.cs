using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantLocationAll
{
    public class GetApplicantLocationAllQueryHandler : IRequestHandler<GetApplicantLocationAllQuery, IEnumerable<Domain.Models.LocationApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantLocationAllQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationApplicationAnalytic>> Handle(GetApplicantLocationAllQuery request, CancellationToken cancellationToken)
        {
            var locationApplicationList = await _context.LocationApplicationAnalytic.ToListAsync();
            if (locationApplicationList == null)
                return null;

            return locationApplicationList.AsReadOnly();
        }
    }
}
