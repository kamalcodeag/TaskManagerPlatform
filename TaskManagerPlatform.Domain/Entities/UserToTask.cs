using System;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class UserToTask : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}