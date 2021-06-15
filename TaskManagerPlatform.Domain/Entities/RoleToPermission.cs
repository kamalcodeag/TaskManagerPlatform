using System;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class RoleToPermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}