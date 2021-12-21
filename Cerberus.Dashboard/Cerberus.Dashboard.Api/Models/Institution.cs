using Cerberus.Dashboard.Api.Models.Contracts;

namespace Cerberus.Dashboard.Api.Models
{
    public class Institution : Entity
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public bool IsMainCampus { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
    }
}
