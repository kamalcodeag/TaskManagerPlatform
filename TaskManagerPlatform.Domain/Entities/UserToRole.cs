using System;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class UserToRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}