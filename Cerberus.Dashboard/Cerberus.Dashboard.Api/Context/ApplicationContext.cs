using Cerberus.Dashboard.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Context
{
    // For futre reuse make the DB context generic please*
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }

    }
}
