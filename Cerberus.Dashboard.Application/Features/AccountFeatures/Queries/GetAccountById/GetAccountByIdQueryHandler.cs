using Cerberus.Dashboard.Application.Exceptions;
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

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountResponseViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AccountResponseViewModel> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == query.Id);
            if (account == null) throw new NotFoundException("Account does not exist");
            return account.ToViewModelEntity(null);
        }
    }
}
