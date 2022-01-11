using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationsCompleted
{
    public class GetApplicationsCompletedQueryHandler : IRequestHandler<GetApplicationsCompletedQuery, IEnumerable<Domain.Models.CompletedApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicationsCompletedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompletedApplicationAnalytic>> Handle(GetApplicationsCompletedQuery request, CancellationToken cancellationToken)
        {
            var completedApplicationList = await _context.CompletedApplicationAnalytic.ToListAsync();
            if (completedApplicationList == null)
                return null;

            return completedApplicationList.AsReadOnly();
        }
    }
}
