using Cerberus.Dashboard.Application.Exceptions;
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
    public class VerifyAccountOtpCommand: IRequest<int>
    {
        public string OtpVerification { get; set; }
    }

    public class VerifyAccountOtpCommandHandler : IRequestHandler<VerifyAccountOtpCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public VerifyAccountOtpCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(VerifyAccountOtpCommand command, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.OTPVerification == command.OtpVerification);
            if (account == null) throw new ForbiddenException("This operation is not permitted");
            account.IsVerified = true;
            account.OTPVerification = null;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account.Id;
        }
    }
}
