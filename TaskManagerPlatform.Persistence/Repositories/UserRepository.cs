using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Domain.Entities;
using TaskManagerPlatform.Persistence.Contexts;

namespace TaskManagerPlatform.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TaskManagerPlatformDbContext dbContext) : base(dbContext) {}

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}