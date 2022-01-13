using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Commands
{
    public class LogoutAccountCommand : IRequest<bool>
    {
        public int AccountId { get; set; }
    }
    public class LogoutAccountCommandHandler : IRequestHandler<LogoutAccountCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public LogoutAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(LogoutAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == command.AccountId);
            if (account == null) throw new Exception("Invalid user account");
            account.Token = null;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
