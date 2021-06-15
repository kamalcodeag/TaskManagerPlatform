using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RoleToPermission> RoleToPermissions { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }
    }
}