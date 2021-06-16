using System;
using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid? StatusId { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<UserToTask> UserToTasks { get; set; }
    }
}