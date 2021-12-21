using Cerberus.Dashboard.Api.Context;
using Cerberus.Dashboard.Api.Services;
using Cerberus.Dashboard.Api.Services.Contracts;
using Cerberus.Dashboard.Api.Services.UnitOfWork;
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
            AddDatabase(services, configuration);
            AddUnitOfWork(services);
            AddServices(services);
            AddMediatR(services);
            AddCors(services);
      
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(o =>
            o.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
        }

        private static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<DbContext>(o => o.GetService<ApplicationContext>());

            services.AddScoped<IUnitOfWork>(
                uow => new EFUnitOfWork(uow.GetRequiredService<ApplicationContext>()));
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
