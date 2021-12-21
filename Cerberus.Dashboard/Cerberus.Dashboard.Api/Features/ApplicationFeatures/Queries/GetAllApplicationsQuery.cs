using Cerberus.Dashboard.Api.Context;
using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.ApplicationFeatures.Queries
{
    public class GetAllApplicationsQuery : IRequest<IEnumerable<Application>>
    {
        public class GetAllApplicationsQueryHandler : IRequestHandler<GetAllApplicationsQuery, IEnumerable<Application>>
        {
            private readonly IApplicationService _service;

            public GetAllApplicationsQueryHandler(IApplicationService service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Application>> Handle(GetAllApplicationsQuery request, CancellationToken cancellationToken)
            {
                var productList = await _service.GetApplicationsAsync();
#pragma warning disable CS8603 // Possible null reference return.
                if (productList == null) { return null; }
#pragma warning restore CS8603 // Possible null reference return.
                return productList;
            }
        }

    }
}
