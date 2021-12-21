using MediatR;

namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<Domain.Models.Account>
    {
        public int AccountId { get; set; }
    }
}
