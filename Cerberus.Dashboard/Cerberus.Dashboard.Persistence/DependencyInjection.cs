using Cerberus.Dashboard.Application;
using Cerberus.Dashboard.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
                o.UseNpgsql(
                            configuration.GetConnectionString("DefaultConnection"),
                                      b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));       

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
