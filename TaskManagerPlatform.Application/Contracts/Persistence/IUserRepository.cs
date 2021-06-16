using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
    }
}