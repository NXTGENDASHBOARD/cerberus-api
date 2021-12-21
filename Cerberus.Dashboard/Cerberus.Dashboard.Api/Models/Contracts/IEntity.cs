using System;
using System.ComponentModel.DataAnnotations;

namespace Cerberus.Dashboard.Api.Models.Contracts
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
