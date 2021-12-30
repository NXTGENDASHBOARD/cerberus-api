using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetAllApplications
{
    public class GetAllApplicationsQueryHandler : IRequestHandler<GetAllApplicationsQuery, IEnumerable<Domain.Models.Application>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllApplicationsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.Models.Application>> Handle(GetAllApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applicationList = await _context.Applications.ToListAsync();

            if (applicationList == null)
            return null; 
            

            return applicationList.AsReadOnly();
        }
    }
}
