namespace Cerberus.Dashboard.Domain.Models
{
    public class AccountRole : AuditEntity<int>
    {
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}