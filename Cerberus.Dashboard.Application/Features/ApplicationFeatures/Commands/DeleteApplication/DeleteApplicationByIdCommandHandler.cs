using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.ApplicationFeatures.Commands.DeleteApplication
{
    public class DeleteApplicationByIdCommandHandler : IRequestHandler<DeleteApplicationByIdCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteApplicationByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteApplicationByIdCommand command, CancellationToken cancellationToken)
        {
            var applicationToDelete = await _context.Applications.FirstOrDefaultAsync(x => x.Id == command.Id);
            if (applicationToDelete == null) return default;
            _context.Applications.Remove(applicationToDelete);
            await _context.SaveChangesAsync();
            return applicationToDelete.Id;
        }
    }
}
