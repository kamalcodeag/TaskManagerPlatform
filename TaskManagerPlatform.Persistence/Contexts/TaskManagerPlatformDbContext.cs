using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Common;
using TaskManagerPlatform.Domain.Entities;
using TaskManagerPlatform.Persistence.Extensions;

namespace TaskManagerPlatform.Persistence.Contexts
{
    public class TaskManagerPlatformDbContext: DbContext
    {
        public TaskManagerPlatformDbContext(DbContextOptions<TaskManagerPlatformDbContext> options) : base(options) {}

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleToPermission> RoleToPermissions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TaskManagerPlatform.Domain.Entities.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToRole> UserToRoles { get; set; }
        public DbSet<UserToTask> UserToTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}