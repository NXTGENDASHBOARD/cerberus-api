using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.InstitutionFeatures.Queries
{
    public class GetInstitutionByIdQuery : IRequest<Institution>
    {
        public int Id { get; set; }

        public class GetInstitutionByIdQueryHandler : IRequestHandler<GetInstitutionByIdQuery, Institution>
        {
            private readonly IInstitutionService _service;

            public GetInstitutionByIdQueryHandler(IInstitutionService service)
            {
                _service = service;
            }
            public async Task<Institution> Handle(GetInstitutionByIdQuery query, CancellationToken cancellationToken)
            {
                var institution = await _service.GetInstitutionByIdAsync(query.Id);
                return institution ?? null;
            }
        }
    }
}
