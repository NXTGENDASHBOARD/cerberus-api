using Cerberus.Dashboard.Application.Services.Security;
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
    public class LoginAccountCommand : IRequest<int>
    {
        public string StaffNumber { get; set; }
        public string Pin { get; set; }

    }
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public LoginAccountCommandHandler(IEncryptionService encryptionService, IApplicationDbContext context)
        {
            _encryptionService = encryptionService;
            _context = context;
        }
        public async Task<int> Handle(LoginAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.StaffNumber == command.StaffNumber);
            if (account == null) throw new Exception("Invalid user account");
            // if Google and other third party sign-ins no password will be stored.
            if (command.Pin != null)
                if (!_encryptionService.IsValidPassword(command.Pin, account.PasswordHash))
                    throw new Exception("Email or password is invalid");

            return account.Id;
        }
    }
}
