using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnline.Domain;

namespace LojaOnline.Domain.Shared
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
