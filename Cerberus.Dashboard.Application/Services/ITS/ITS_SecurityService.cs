using Cerberus.Dashboard.Domain.ITSModels;
using ITSApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Services.ITS
{
    public interface IITS_SecurityService
    {
        Task<UserAccessResponseModel> verifyUserAccess(string token);
    }

    public class ITS_SecurityService : IITS_SecurityService
    {
        public async Task<UserAccessResponseModel> verifyUserAccess(string token)
        {
            using var client = new HttpClient();

            var apiClient = new StudentApi_Client(client);
            var result = new UserAccessResponseModel();
            try
            {
                var user = await apiClient.UseraccessAsync(token);
                if (user == null) return null;

                // Map basic user info
                result.Names = user.Names;
                result.Surname = user.Surname;
                result.Status = user.Status;
                result.Title = user.Title;

                // Map roles
                ProcessUserAccessRoles(result, user);

                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void ProcessUserAccessRoles(UserAccessResponseModel result, Response34 user)
        {
            if (user.Roles.Any())
            {
                result.Roles = new List<UserAccessRoleModel>();
                foreach (var role in user.Roles)
                {
                    var roleModel = new UserAccessRoleModel();
                    roleModel.Name = role.Role;
                    roleModel.Descr = role.Descr;
                    roleModel.Acceslevel = role.AccessLevel ?? role.AdditionalProperties["acceslevel"] as string ?? null;
                    string sourceCode = null;
                    foreach (var item in role.SourceLst)
                    {
                        sourceCode = item.SourceCode;
                    };
                    roleModel.AccessCode = sourceCode;              
                    
                    result.Roles.Add(roleModel);
                }
            }
        }
    }
}
