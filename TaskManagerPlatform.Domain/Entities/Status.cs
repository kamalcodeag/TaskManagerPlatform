using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}