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
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Domain.Models.Account>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Models.Account> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == query.AccountId );
            if(account == null) return null;
            return account;
        }
    }
}
