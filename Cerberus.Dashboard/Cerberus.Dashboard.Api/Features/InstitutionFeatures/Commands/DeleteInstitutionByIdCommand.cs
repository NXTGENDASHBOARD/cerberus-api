using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.InstitutionFeatures.Commands
{
    public class DeleteInstitutionByIdCommand: IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteInstitutionByIdCommandHandler : IRequestHandler<DeleteInstitutionByIdCommand, int>
        {
            private readonly IInstitutionService _service;

            public DeleteInstitutionByIdCommandHandler(IInstitutionService service)
            {
                _service = service;
            }
            public async Task<int> Handle(DeleteInstitutionByIdCommand request, CancellationToken cancellationToken)
            {
               var institutionToDelete = await _service.GetInstitutionByIdAsync(request.Id);
                if (institutionToDelete == null) return default;
                return await _service.DeleteInstitutionAsync(institutionToDelete);
            }
        }
    }
}
