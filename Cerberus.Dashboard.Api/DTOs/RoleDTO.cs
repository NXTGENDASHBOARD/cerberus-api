using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cerberus.Dashboard.Api.DTOs
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AccessLevel { get; set; }

        [JsonIgnore]
        public Dictionary<string,string> SourceList { get; set; }
    }
}
