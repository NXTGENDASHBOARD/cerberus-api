using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            var applications = await GetApplicationsAsync();
            if (applications.Any())
            {
                return applications?.FirstOrDefault(app => app.Id == id);

            } else { return null; }
 
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
             return await _unitOfWork.QueryAsync<Application>();
        }
        public async Task<int> CreateApplicationAsync(Application application)
        {
            var added = await _unitOfWork.AddAsync(application);
            if (added > 0)
            {
                await _unitOfWork.CommitAsync();
            }
            else { return 0; }

            return application.Id;
        }

        public async Task<int> DeleteApplicationAsync(Application application)
        {
            if (await _unitOfWork.RemoveAsync(application) > 0)
            {
                await _unitOfWork.CommitAsync();
            }
            else { return 0; }

            return application.Id;
        }


        public async Task<int> UpdateApplicationAsync(Application application)
        {
           if(await _unitOfWork.UpdateAsync(application) > 0)
            {
                await _unitOfWork.CommitAsync();
            }
           else { return 0; }

            return application.Id;

        }
    }
}
