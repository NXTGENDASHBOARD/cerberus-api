using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationById
{
    public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, Domain.Models.Application>
    {

        private readonly IApplicationDbContext _context;

        public GetApplicationByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Models.Application> Handle(GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(x => x.Id == query.Id);
            if (application == null) return null;
            return application;
        }
    }
}
