using Cerberus.Dashboard.Api.Models;
using Cerberus.Dashboard.Api.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstitutionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Institution> GetInstitutionByIdAsync(int id)
        {
            var institutions = await GetInstitutionsAsync();
            if (institutions.Any())
            {
                return institutions.FirstOrDefault(ins => ins.Id == id);
            }
            else return null;
        }

        public async Task<IEnumerable<Institution>> GetInstitutionsAsync()
        {
            return await _unitOfWork.QueryAsync<Institution>();
        }

        public async Task<int> CreateInstitutionAsync(Institution institution)
        {
            var added = await _unitOfWork.AddAsync(institution);
            if (added > 0) { await _unitOfWork.CommitAsync(); }
            else return 0;

            return institution.Id;
        }


        public async Task<int> DeleteInstitutionAsync(Institution institution)
        {
            if (await _unitOfWork.RemoveAsync(institution) > 0)
            {
                await _unitOfWork.CommitAsync();
            }
            else return 0;

            return institution.Id;
        }

        public async Task<int> UpdateInstitutionAsync(Institution institution)
        {
            if (await _unitOfWork.UpdateAsync(institution) > 0)
            {
                await _unitOfWork.CommitAsync();
            }
            else return 0;

            return institution.Id;
        }

    }
}
