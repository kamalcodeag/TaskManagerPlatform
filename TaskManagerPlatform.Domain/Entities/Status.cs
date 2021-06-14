using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}