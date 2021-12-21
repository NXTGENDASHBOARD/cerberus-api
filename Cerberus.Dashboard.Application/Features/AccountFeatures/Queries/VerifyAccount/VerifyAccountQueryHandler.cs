using Cerberus.Dashboard.Application.Services.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.VerifyAccount
{
    public class VerifyAccountQueryHandler : IRequestHandler<VerifyAccountQuery, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEncryptionService _encryptionService;
        public VerifyAccountQueryHandler(IApplicationDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<int> Handle(VerifyAccountQuery query, CancellationToken cancellationToken)
        {

            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.StaffNumber == query.StaffNumber);
            if (account == null || !account.IsVerified)
                throw new Exception("Account must be verified");
            if (!_encryptionService.IsValidPassword(query.Pin.ToString(), account.PasswordHash))
                throw new Exception("Email or password is invalid");

            return account.Id;
        }
    }
}
