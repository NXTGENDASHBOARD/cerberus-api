using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicantAPSDistribution
{
    public class GetApplicantAPSDistributionQueryHandler : IRequestHandler<GetApplicantAPSDistributionQuery, IEnumerable<Domain.Models.DistributionApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicantAPSDistributionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public  async Task<IEnumerable<DistributionApplicationAnalytic>> Handle(GetApplicantAPSDistributionQuery request, CancellationToken cancellationToken)
        {
            var distributionApplicationList = await _context.DistributionApplicationAnalytic.ToListAsync();
            if (distributionApplicationList == null)
                return null;

            return distributionApplicationList.AsReadOnly();
        }
    }
}
