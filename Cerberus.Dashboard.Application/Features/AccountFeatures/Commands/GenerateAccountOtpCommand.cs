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
    public class GenerateAccountOtpCommand : IRequest<int>
    {
        public string Email { get; set; }
    }

    public class GenerateAccountOtpCommandHandler : IRequestHandler<GenerateAccountOtpCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly Random _random = new Random();
        public GenerateAccountOtpCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GenerateAccountOtpCommand command, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == command.Email);
            if (account == null) throw new NotFoundException("Account does not exist");
            // Generate OTP
            var otp = _random.Next().ToString().Substring(0, 4);
            account.OTPVerification = otp;
            account.IsVerified = false;

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();

            return account.Id;
        }
    }
}
