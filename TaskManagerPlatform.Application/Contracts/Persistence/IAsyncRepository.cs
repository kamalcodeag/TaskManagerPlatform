using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Common;

namespace TaskManagerPlatform.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync(int takeCount = 50, int skipCount = 0);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}