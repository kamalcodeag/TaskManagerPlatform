using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Domain.Common;
using TaskManagerPlatform.Persistence.Contexts;

namespace TaskManagerPlatform.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly TaskManagerPlatformDbContext _dbContext;

        public BaseRepository(TaskManagerPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(int takeCount = 50, int skipCount = 0)
        {
            return await _dbContext.Set<T>().Take(takeCount).Skip(skipCount).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}