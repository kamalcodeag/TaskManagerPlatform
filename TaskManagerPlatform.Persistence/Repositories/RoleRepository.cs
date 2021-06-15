using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Domain.Entities;
using TaskManagerPlatform.Persistence.Contexts;

namespace TaskManagerPlatform.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(TaskManagerPlatformDbContext dbContext) : base(dbContext) {}

        public async Task<Role> GetRoleByName(string roleName)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        }
    }
}