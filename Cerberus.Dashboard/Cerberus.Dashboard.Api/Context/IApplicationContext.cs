using Cerberus.Dashboard.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Context
{
    public interface IApplicationContext
    {
        DbSet<Application> Applications { get; set; }
        DbSet<Institution> Institutions { get; set; }

        Task<int> SaveChangesAsync();
    }
}