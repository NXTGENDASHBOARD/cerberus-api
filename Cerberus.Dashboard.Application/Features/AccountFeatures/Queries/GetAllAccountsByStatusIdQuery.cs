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
    public class GetAllAccountsByStatusIdQuery : IRequest<List<AccountResponseViewModel>>
    {
        public int StatusId { get; set; }
    }

    public class GetAllAccountsByStatusIdQueryHandler : IRequestHandler<GetAllAccountsByStatusIdQuery, List<AccountResponseViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAccountsByStatusIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountResponseViewModel>> Handle(GetAllAccountsByStatusIdQuery query, CancellationToken cancellationToken)
        {
            var accounts = await _context.Accounts.ToListAsync();

            if (accounts == null) return null;

            return accounts.Select(account => account.ToViewModelEntity(null)).ToList();
        }
    }
}
