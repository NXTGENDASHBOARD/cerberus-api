using Cerberus.Dashboard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<AccountRole> AccountRoles { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }

        DbSet<Domain.Models.Application> Applications { get; set; }
        DbSet<Institution> Institutions { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<CompletedApplicationAnalytic> CompletedApplicationAnalytic { get; set; }
        public DbSet<FacultyApplicationAnalytic> FacultyApplicationAnalytic { get; set; }

        public DbSet<PipelineApplicationAnalytic> PipelineApplicationAnalytic { get; set; }
        public DbSet<CourseTypeApplicationAnalytic> CourseTypeApplicationAnalytic { get; set; }
        public DbSet<DistributionApplicationAnalytic> DistributionApplicationAnalytic { get; set; }
        public DbSet<FeederSchoolApplicationAnalytic> FeederSchoolApplicationAnalytic { get; set; }
        public DbSet<RaceApplicationAnalytic> RaceApplicationAnalytic { get; set; }

        public DbSet<GenderApplicationAnalytic> GenderApplicationAnalytic { get; set; }
        public DbSet<LocationApplicationAnalytic> LocationApplicationAnalytic { get; set; }

        Task<int> SaveChangesAsync();
    }
}
