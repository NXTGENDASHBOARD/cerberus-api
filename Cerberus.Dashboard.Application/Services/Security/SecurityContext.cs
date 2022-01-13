using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Services.Security
{
    public interface ISecurityContext
    {
        Domain.Models.Account Account { get; }
        bool IsAdministrator { get; }
        bool IsStaff { get; }
    }

    public class SecurityContext : ISecurityContext
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public SecurityContext(IApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        private Domain.Models.Account account;

        public Domain.Models.Account Account
        {
            get
            {
                if (account != null) return account;

                if (!_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                    throw new Exception("unauthorized");
                var email = _contextAccessor.HttpContext.User.Identity.Name;

                account = _context.Accounts.FirstOrDefaultAsync(x => x.Email == email).Result;

                if (account == null)
                    throw new Exception("unauthorized a-2");
                return account;
            }
        }

        public bool IsAdministrator => throw new NotImplementedException();

        public bool IsStaff => throw new NotImplementedException();

        //public bool IsAdministrator
        //{
        //    get { return Account.Role == Domain.Models.RoleEnum.Admin; }
        //}

        //public bool IsStaff
        //{
        //    get { return Account.Role == Domain.Models.RoleEnum.Staff; }
        //}

    }
}
