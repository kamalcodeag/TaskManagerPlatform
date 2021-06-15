using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Application.Contracts.Persistence
{
    public interface IRoleRepository : IAsyncRepository<Role>
    {
        Task<Role> GetRoleByName(string roleName);
    }
}