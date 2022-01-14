using Cerberus.Dashboard.Api.Authorize;
using Cerberus.Dashboard.Api.DTOs;
using Cerberus.Dashboard.Application.Extensions.Account;
using Cerberus.Dashboard.Application.Extensions.Email;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Commands;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Commands.VerifyITSUserAccess;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Queries;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.GetAccountById;
using Cerberus.Dashboard.Application.Features.AccountFeatures.Queries.VerifyAccount;
using Cerberus.Dashboard.Application.ViewModels.Account;
using Cerberus.Dashboard.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Controllers
{
    [Authorize]
    [Route("api/account")]
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginAccountViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var command = model.ToCommandViewModel();
            var accountId = await _mediator.Send(command);
            if (accountId == 0) return BadRequest("Failed to login");
            if (await _mediator.Send(new AuthenticateAccountCommand { AccountId = accountId }) == 0) return BadRequest("Failed to Authenticate");
            var account = await _mediator.Send(new GetAccountDetailsByIdQuery { AccountId = accountId });
            if (account == null) return BadRequest("Failed to retrieve account details");
            return Ok(account);
        }

        [AllowAnonymous]
        [HttpPost("itslogin")]
        public async Task<IActionResult> ItsLoginAsync([FromBody] LoginDTO model)
        {
            var account = await _mediator.Send(new VerifyITSUserAccessCommand
            {
                StaffNumber = model.StaffNumber,
                Pin = model.Pin
            });
            return Ok(account);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingUser = await _mediator.Send(new GetAccountByEmailQuery { Email = model.Email });

            if (existingUser != null && existingUser.Email == model.Email && existingUser.IsActive)
                return BadRequest("This account is in use");

            var command = model.ToCommandViewModel();
            var accountId = await _mediator.Send(command);

            if (accountId == 0) return BadRequest("Failed to register");

            var indicator = await SendOTPEmail(accountId, Request.Headers["origin"]);

            if (indicator == 0)
            {
                _logger.LogError("OTP Email could not be sent");
            }
            else
            {
                _logger.LogInformation("OTP Email was sent");
            }

            return Ok(accountId);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var currentUser = (AccountDetailsResponseViewModel)HttpContext.Items["User"];
            if (currentUser == null) return BadRequest("internal server error, contact sys admin");
            return Ok(await _mediator.Send(new LogoutAccountCommand { AccountId = currentUser.Id }));
        }

        [Authorize(RoleEnum.Admin)]
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var accounts = await _mediator.Send(new GetAllAccountsByStatusIdQuery { StatusId = 1 });
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // only admins can access other  user records
            var currentUser = (AccountDetailsResponseViewModel)HttpContext.Items["User"];

            if (id != currentUser.Id &&
                !currentUser.Roles.Any(x =>
                x.RoleName == RoleEnum.Admin.ToString()))
                return Unauthorized(new { message = "Unauthorized" });

            var account = await _mediator.Send(new GetAccountDetailsByIdQuery { AccountId = id });
            return Ok(account);

        }


        [AllowAnonymous]
        [HttpPost("request-otp")]
        public async Task<IActionResult> RequestOtpAsync([FromBody] AccountVerificationRequestOtpViewModel model)
        {
            // Generate OTP Command
            var accountId = await _mediator.Send(new GenerateAccountOtpCommand { Email = model.Email });
            if (accountId == 0) return BadRequest("Failed to generate OTP");
            // Send Email with OTP code
            var indicator = await SendOTPEmail(accountId, Request.Headers["origin"]);

            if (indicator == 0)
            {
                _logger.LogError("OTP Email could not be sent");
            }
            else
            {
                _logger.LogInformation("OTP Email was sent");
            }
            return Ok(accountId);
        }

        [AllowAnonymous]
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtpAsync([FromBody] AccountVerificationOtpViewModel model)
        {
            // Verify Otp Command
            var accountId = await _mediator.Send(new VerifyAccountOtpCommand { OtpVerification = model.OTPVerification });
            if (accountId == 0) return BadRequest("Failed to verify OTP");
            return Ok(accountId);
        }
        private async Task<int> SendOTPEmail(int id, string origin)
        {
            var account = await _mediator.Send(new GetAccountByIdQuery { Id = id });
            if (account == null) return default;

            return await _mediator.Send(new SendOtpEmailCommand
            {
                FullName = account.FirstName + " " + account.Surname,
                To = new List<string> { account.Email },
                OtpCode = account.OTP,
                Origin = origin
            });

        }
    }
}
