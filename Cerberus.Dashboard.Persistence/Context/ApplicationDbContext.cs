using Cerberus.Dashboard.Application;
using Cerberus.Dashboard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Domain.Models.Application> Applications { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }
    }
}
