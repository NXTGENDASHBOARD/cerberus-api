using Cerberus.Dashboard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedRoles();
            builder.SeedPermissions();
            builder.SeedRolePermissions();
        }
        public static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                RoleName = RoleConstants.Admin,
                Description = "An administrator role normaly does everything",
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                CreateUserId = "builder.seed",
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = "builder.seed",
                StatusId = 1,
            },
            new Role
            {
                Id = 2,
                RoleName = RoleConstants.Dean,
                Description = "An dean role of the university generaly views only.",
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                CreateUserId = "builder.seed",
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = "builder.seed",
                StatusId = 1
            },
            new Role
            {
                Id = 3,
                RoleName = RoleConstants.Lecturer,
                Description = "An dean role of the university views their own department.",
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                CreateUserId = "builder.seed",
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = "builder.seed",
                StatusId = 1
            },
             new Role
             {
                 Id = 4,
                 RoleName = RoleConstants.FacultyOfficer,
                 Description = "An Faculty officer role of the university views their own faculty.",
                 CreatedDate = DateTime.UtcNow.ToLocalTime(),
                 CreateUserId = "builder.seed",
                 ModifyDate = DateTime.UtcNow.ToLocalTime(),
                 ModifyUserId = "builder.seed",
                 StatusId = 1
             }
            );

        }


        public static void SeedPermissions(this ModelBuilder builder)
        {
            builder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    PermissionName = "All",
                    Description = "Has a super user access level granted can do anything",
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                },
                new Permission
                {
                    Id = 2,
                    PermissionName = "Basic",
                    Description = "Can do basic things not everything",
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                }, new Permission
                {
                    Id = 3,
                    PermissionName = "ViewOnly",
                    Description = "Can only view data can not modify data",
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                });
        }

        public static void SeedRolePermissions(this ModelBuilder builder)
        {
            builder.Entity<RolePermission>().HasData(
                new RolePermission
                {
                    Id = 1,
                    RoleId = 1,
                    PermissionId = 1,
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                },
                new RolePermission
                {
                    Id = 2,
                    RoleId = 2,
                    PermissionId = 3,
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                },
                new RolePermission
                {
                    Id = 3,
                    RoleId = 3,
                    PermissionId = 2,
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                },
                new RolePermission
                {
                    Id = 4,
                    RoleId = 4,
                    PermissionId = 2,
                    CreatedDate = DateTime.UtcNow.ToLocalTime(),
                    CreateUserId = "builder.seed",
                    ModifyDate = DateTime.UtcNow.ToLocalTime(),
                    ModifyUserId = "builder.seed",
                    StatusId = 1
                });
        }

    }
}
