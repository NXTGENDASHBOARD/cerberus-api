using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Domain.Models
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
        public int StatusId { get; set; }
    }
}
