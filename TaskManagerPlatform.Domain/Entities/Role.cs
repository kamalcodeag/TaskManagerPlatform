using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RoleToPermission> RoleToPermissions { get; set; }
        public ICollection<UserToRole> UserToRoles { get; set; }
    }
}