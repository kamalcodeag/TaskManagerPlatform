using System;
using System.Collections.Generic;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public Guid? OrganizationId { get; set; }
        public virtual User Organization { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }
        public virtual ICollection<UserToTask> UserToTasks { get; set; }
        public virtual ICollection<User> Employees { get; set; }
    }
}