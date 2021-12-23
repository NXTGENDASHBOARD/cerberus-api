using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cerberus.Dashboard.Api.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string StaffNumber { get; set; }

        [Required]
        public int Pin { get; set; }
    }

    public class LoginResponseDto
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public string Token { get; set; }

        public List<RoleDTO> Roles { get; set; }
    }
}
