using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Application.Contracts.Persistence
{
    public interface IRoleRepository : IAsyncRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<List<Role>> GetRolesOfUserAsync(Guid userId);
    }
}