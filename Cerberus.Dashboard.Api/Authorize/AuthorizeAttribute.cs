using Cerberus.Dashboard.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerberus.Dashboard.Api.Authorize
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<RoleEnum> _roles;

        public AuthorizeAttribute(params RoleEnum[] roles)
        {
            _roles = roles ?? new RoleEnum[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            //var account = (AccountDetailsResponseViewModel)context.HttpContext.Items["User"];

            //if (account == null)
            //{
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //    return;
            //}

            //var hasRole = account.Roles.Any(x => _roles
            //    .Contains((RoleEnum)Enum
            //    .Parse(typeof(RoleEnum),
            //    x.RoleName)));


            //if (account == null || (_roles.Any() && !hasRole))
            //{
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //}
        }
    }
}
