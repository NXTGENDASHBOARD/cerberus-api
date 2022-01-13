using Cerberus.Dashboard.Application.Constants;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Queries;
using Cerberus.Dashboard.Application.Services.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Authorize
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext context, IMediator _mediator, ITokenService tokenService)
        {
            // Get token from the front-end
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var accountId = tokenService.ValidateToken(token);
            if (accountId != null)
            {
                // attach account to context on successfully validation
                context.Items["User"] = await _mediator.Send(new GetAccountDetailsByIdQuery { AccountId = (int)accountId });
            }
            await _next(context);
        }
    }
}
