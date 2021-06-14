using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<RoleToPermission> RoleToPermissions { get; set; }
    }
}