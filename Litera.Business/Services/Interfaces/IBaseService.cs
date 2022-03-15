using Litera.Data.Entities;
using System.Linq.Expressions;

namespace Litera.Business.Services.Interfaces
{
    public interface IBaseService<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : class
    {
        Task Create(TViewModel model);
        Task<bool> Delete(Guid id);
        ValueTask<TViewModel> GetById(Guid id);
        Task<TEntity> OnBeforeCreate(TViewModel model);
        Task<TEntity> OnBeforeUpdate(TViewModel model);
        Task Update(TViewModel model);
        Task<List<TViewModel>> GetAllAsync(Expression<Func<TViewModel, bool>>? filter = null);
    }
}