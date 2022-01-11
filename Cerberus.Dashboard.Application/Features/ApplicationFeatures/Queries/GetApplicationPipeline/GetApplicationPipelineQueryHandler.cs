using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cerberus.Dashboard.Domain.Models;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Queries.GetApplicationPipeline
{
    public class GetApplicationPipelineQueryHandler : IRequestHandler<GetApplicationPipelineQuery, IEnumerable<Domain.Models.PipelineApplicationAnalytic>>
    {
        private readonly IApplicationDbContext _context;

        public GetApplicationPipelineQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PipelineApplicationAnalytic>> Handle(GetApplicationPipelineQuery request, CancellationToken cancellationToken)
        {
            var pipelineApplicationList = await _context.PipelineApplicationAnalytic.ToListAsync();
            if (pipelineApplicationList == null)
                return null;

            return pipelineApplicationList.AsReadOnly();
        }
    }
}
