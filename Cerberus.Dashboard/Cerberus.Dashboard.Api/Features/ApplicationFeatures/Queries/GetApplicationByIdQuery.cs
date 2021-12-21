using Cerberus.Dashboard.Api.Context;
using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.ApplicationFeatures.Queries
{
    public class GetApplicationByIdQuery : IRequest<Application>
    {
        public int Id { get; set; }

        public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, Application>
        {
            private readonly IApplicationService _service;

            public GetApplicationByIdQueryHandler(IApplicationService service)
            {
                _service = service;
            }

            public async Task<Application> Handle(GetApplicationByIdQuery query, CancellationToken cancellationToken)
            {
                var application = await _service.GetApplicationByIdAsync(query.Id);

#pragma warning disable CS8603 // Possible null reference return.
                return application ?? null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
