using Cerberus.Dashboard.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Services.Contracts
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(int id);
        Task<int> CreateApplicationAsync(Application application);
        Task<int> UpdateApplicationAsync(Application application);
        Task<int> DeleteApplicationAsync(Application application);
    }
}
