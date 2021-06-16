using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Domain.Entities;
using TaskManagerPlatform.Persistence.Contexts;

namespace TaskManagerPlatform.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(TaskManagerPlatformDbContext dbContext) : base(dbContext) {}

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        }

        public async Task<List<Role>> GetRolesOfUserAsync(Guid userId)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            List<UserToRole> userToRoles = await _dbContext.UserToRoles.Where(utr => utr.UserId == userId).ToListAsync();
            List<Role> roles = null;

            foreach (var userToRole in userToRoles)
            {
                roles.Add(userToRole.Role);
            }

            return roles;
        }
    }
}