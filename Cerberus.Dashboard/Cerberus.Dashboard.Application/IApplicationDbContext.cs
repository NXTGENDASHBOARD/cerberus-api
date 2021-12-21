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

        Task<int> SaveChangesAsync();
    }
}
