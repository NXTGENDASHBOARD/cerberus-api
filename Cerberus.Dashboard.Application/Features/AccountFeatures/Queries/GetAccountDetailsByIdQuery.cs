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

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Queries
{
    public class GetAccountDetailsByIdQuery : IRequest<AccountDetailsResponseViewModel>
    {
        public int AccountId { get; set; }
    }

    public class GetAccountDetailsByIdQueryHandler : IRequestHandler<GetAccountDetailsByIdQuery, AccountDetailsResponseViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountDetailsByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccountDetailsResponseViewModel> Handle(GetAccountDetailsByIdQuery query, CancellationToken cancellationToken)
        {
            // Get account
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == query.AccountId);

            if (account == null) throw new NotFoundException("Account does not exist");

            // Get account roles
            var accountRoles = await _context.AccountRoles
                .Where(x => x.AccountId == account.Id)
                .Include(x => x.Role)
                .ToListAsync();
            var model = account.ToViewModelEntity();

            if (accountRoles.Any())
            {
                foreach (var item in accountRoles)
                {
                    var rolePermissions = await _context.RolePermissions.Where(x => x.RoleId == item.RoleId)
                        .Include(x => x.Permission)
                        .ToListAsync(cancellationToken);

                    var roleToAdd = item.Role.ToViewModelEntity(rolePermissions);
                    model.Roles.Add(roleToAdd);
                }

            }

            return model;


        }
    }
}
