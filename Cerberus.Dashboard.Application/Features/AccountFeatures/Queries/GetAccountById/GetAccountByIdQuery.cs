using Cerberus.Dashboard.Application.ViewModels.Account;
using MediatR;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<AccountResponseViewModel>
    {
        public int Id { get; set; }
    }
}
