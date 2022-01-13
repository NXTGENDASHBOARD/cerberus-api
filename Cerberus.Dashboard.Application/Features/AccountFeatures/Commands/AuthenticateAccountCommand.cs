using Cerberus.Dashboard.Application.Exceptions;
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
    public class AuthenticateAccountCommand : IRequest<int>
    {
        public int AccountId { get; set; }
    }


    public class AuthenticateAccountCommandHandler : IRequestHandler<AuthenticateAccountCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthenticateAccountCommandHandler(IApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }


        public async Task<int> Handle(AuthenticateAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == command.AccountId);

            if (account == null) throw new NotFoundException("Account does not exist");

            var roles = account.Roles.Select(x => x?.Role?.RoleName).ToArray();

            var expiryPeriod = DateTime.Now.ToLocalTime() + TokenAuthOption.ExpiresSpan;

            var token = _tokenService.BuildToken(account, roles, expiryPeriod);

            if (token == null) throw new Exceptions.ArgumentNullException("Token generation failed");

            // Update token
            account.Token = token;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();

            return account.Id;
        }
    }
}
