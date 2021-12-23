using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.ITSModels
{
    public class UserAccessModel
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("userid")]
        public string Userid { get; set; }

        [JsonProperty("staffnumber")]
        public string Staffnumber { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("rol")]
        public string Rol { get; set; }

        [JsonProperty("iat")]
        public string Iat { get; set; }


    }
}
