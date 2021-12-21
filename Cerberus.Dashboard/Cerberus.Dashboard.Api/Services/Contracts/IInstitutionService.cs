using Cerberus.Dashboard.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Services.Contracts
{
    public interface IInstitutionService
    {
        Task<int> CreateInstitutionAsync(Institution institution);
        Task<int> DeleteInstitutionAsync(Institution institution);
        Task<Institution> GetInstitutionByIdAsync(int id);
        Task<IEnumerable<Institution>> GetInstitutionsAsync();
        Task<int> UpdateInstitutionAsync(Institution institution);
    }
}