using Cerberus.Dashboard.Api.Context;
using Cerberus.Dashboard.Api.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Features.ApplicationFeatures.Commands
{
    public class DeleteApplicationByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteApplicationByIdCommandHandler : IRequestHandler<DeleteApplicationByIdCommand, int>
        {
            private readonly IApplicationService _service;

            public DeleteApplicationByIdCommandHandler(IApplicationService service)
            {
                _service = service;
            }
            public async Task<int> Handle(DeleteApplicationByIdCommand command, CancellationToken cancellationToken)
            {
                var applicationToDelete = await _service.GetApplicationByIdAsync(command.Id);
                if (applicationToDelete == null) return default;
                return await _service.DeleteApplicationAsync(applicationToDelete);
            }
        }
    }
}
