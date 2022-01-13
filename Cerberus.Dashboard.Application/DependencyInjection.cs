using Cerberus.Dashboard.Application.Services.Email;
using Cerberus.Dashboard.Application.Services.ITS;
using Cerberus.Dashboard.Application.Services.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddServices();

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ISecurityContext, SecurityContext>();
            services.AddScoped<IITS_InstitutionService, ITS_InstitutionService>();
            services.AddScoped<IITS_SecurityService, ITS_SecurityService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
