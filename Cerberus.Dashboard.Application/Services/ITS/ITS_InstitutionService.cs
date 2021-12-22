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
        Task getInstitutions();
    }

    public class ITS_InstitutionService : IITS_InstitutionService
    {
        public async Task getInstitutions()
        {
            using var client = new HttpClient();

            var apiClient = new StudentApi_Client(client);

            var institutions = await apiClient.InstitutionAsync();

            Console.WriteLine(institutions);
        }
    }
}
