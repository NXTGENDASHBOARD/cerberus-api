using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cerberus.Dashboard.Api.DTOs
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AccessLevel { get; set; }
        public string AccessCode { get; set; }

    }

}
