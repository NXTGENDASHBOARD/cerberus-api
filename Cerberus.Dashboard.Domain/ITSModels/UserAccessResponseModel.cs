using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.ITSModels
{
    public class UserAccessResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("names")]
        public string Names { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("roles")]
        public List<UserAccessRoleModel> Roles { get; set; }
    }

    public class UserAccessRoleModel
    {
        [JsonProperty("role")]
        public string Name { get; set; }

        [JsonProperty("descr")]
        public string Descr { get; set; }

        [JsonProperty("acceslevel")]
        public string Acceslevel { get; set; }
        [JsonProperty("accesCode")]
        public string AccessCode { get; set; }
    }
}
