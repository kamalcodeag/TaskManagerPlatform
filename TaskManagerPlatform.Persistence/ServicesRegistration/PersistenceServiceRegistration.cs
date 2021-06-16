using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Persistence.Contexts;
using TaskManagerPlatform.Persistence.Repositories;

namespace TaskManagerPlatform.Persistence.ServicesRegistration
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagerPlatformDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TaskManagerPlatformDbContextConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}