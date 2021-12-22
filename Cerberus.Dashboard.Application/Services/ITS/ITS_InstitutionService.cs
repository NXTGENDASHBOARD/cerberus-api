using Cerberus.Dashboard.Domain.Models;
using ITSApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Services.ITS
{
    public interface IITS_InstitutionService
    {
        Task<IEnumerable<Institution>> getInstitutions();
    }

    public class ITS_InstitutionService : IITS_InstitutionService
    {
        public async Task<IEnumerable<Institution>> getInstitutions()
        {
            using var client = new HttpClient();

            var apiClient = new StudentApi_Client(client);

            var institutions = await apiClient.InstitutionAsync();
            // TODO Create extension methods to handle this.
            var insitutionList = new List<Institution>();
            foreach (var institution in institutions.Items)
            {
                var type = institution.InstitutionType;
                insitutionList.Add(new Institution {

                    Id = Convert.ToInt32(institution.InstitutionCode),
                    Name = institution.InstitutionDesc,
                    Region = institution.InstitutionType,               
                
                });
            }

            return insitutionList.AsReadOnly();
        }

    }
}
