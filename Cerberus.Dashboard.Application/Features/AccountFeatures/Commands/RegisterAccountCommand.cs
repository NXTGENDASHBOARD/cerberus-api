using Cerberus.Dashboard.Application.Extensions.Account;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
namespace Cerberus.Dashboard.Application.Features.AccountFeatures.Commands
{

    public class RegisterAccountCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string StaffNumber { get; set; }

        public string Password { get; set; }

        // Used to hash the password dont assign view model property to this.
        public string PasswordHash { get; set; }
        public bool IsThirdParty { get; set; }
        public string ThirdPartyProvider { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsVerified { get; set; }
        public string OTPVerification { get; set; }
        public bool IsActive { get; set; } = true;
        public int StatusId { get; set; }

    }


    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly Random _random = new Random();
        public RegisterAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<int> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            // encrypt password
            command.PasswordHash = command.Password != null ? BC.HashPassword(command.Password) : null;

            // Generate OTP
            var otp = _random.Next().ToString().Substring(0, 4);
            command.OTPVerification = otp;
            var accountToCreate = command.ToEntityCommand();

            if (accountToCreate != null)
            {
                await _context.Accounts.AddAsync(accountToCreate);
                await _context.SaveChangesAsync();

                if (accountToCreate.Id > 0)
                {
                    // Add Account to a role
                    // 1. Get a role
                    var role = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == command.RoleName);

                    if (role != null)
                    {
                        // Using Account Role extensions to map the required fields.

                        var accountRole = accountToCreate.ToEntityAccountRole(role);

                        if (accountRole != null)
                        {
                            await _context.AccountRoles.AddAsync(accountRole);

                        }

                    }

                    await _context.SaveChangesAsync();
                }
                return accountToCreate.Id;
            }

            return default;
        }
    }

}
