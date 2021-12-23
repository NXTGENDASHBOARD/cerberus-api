using Cerberus.Dashboard.Api.DTOs;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.GetAccountById;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.VerifyAccount;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IMediator mediator, ILogger<AccountsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountId = await _mediator.Send(new VerifyAccountQuery
            {
                StaffNumber = model.StaffNumber,
                Pin = model.Pin
            });
            if(accountId == default) return BadRequest(ModelState);
            var account = await _mediator.Send(new GetAccountByIdQuery { AccountId = accountId });

            return Ok(account);
        }
    }
}
