
using Cerberus.Dashboard.Application;
using Cerberus.Dashboard.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cerberus.Dashboard.Api.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(
            IServiceCollection services,
            IConfiguration configuration
            )
        {

            AddCors(services);
            services.AddApplication();
            services.AddPersistence(configuration);
        }

        private static void AddCors(this IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options
                        .AddPolicy("CorsPolicy",
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());
                });
        }
    }
}
