using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagerPlatform.Persistence.Contexts;

namespace TaskManagerPlatform.Persistence
{
    public class TaskManagerPlatformDbContextFactory : IDesignTimeDbContextFactory<TaskManagerPlatformDbContext>
    {
        public TaskManagerPlatformDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskManagerPlatformDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=TaskManagerPlatformDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseLazyLoadingProxies().ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            return new TaskManagerPlatformDbContext(optionsBuilder.Options);
        }
    }
}