using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.InstitutionFeatures.Queries
{
    public class GetAllInstitutionsQuery : IRequest<IEnumerable<Institution>>
    {
        public class GetAllInstitutionsQueryHandler : IRequestHandler<GetAllInstitutionsQuery, IEnumerable<Institution>>
        {
            private readonly IInstitutionService _service;

            public GetAllInstitutionsQueryHandler(IInstitutionService service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Institution>> Handle(GetAllInstitutionsQuery request, CancellationToken cancellationToken)
            {
                var institutionList = await _service.GetInstitutionsAsync();

                if (institutionList == null) return null;

                return institutionList;
            }
        }
    }
}
