using Cerberus.Dashboard.Application.Extensions.Account;
using Cerberus.Dashboard.Application.ViewModels.Account;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Queries
{
    public class GetAccountByEmailQuery : IRequest<AccountResponseViewModel>
    {
        public string Email { get; set; }
    }
    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, AccountResponseViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountByEmailQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AccountResponseViewModel> Handle(GetAccountByEmailQuery query, CancellationToken cancellationToken)
        {
            // Get account
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == query.Email);
            if (account == null) return null;
            return account.ToViewModelEntity(null);
        }
    }
}
