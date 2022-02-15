using Litera.Data.Entities;
using System.Linq.Expressions;

namespace Litera.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        ValueTask<T?> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}