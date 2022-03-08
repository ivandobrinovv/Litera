using Litera.Data.Entities;

namespace Litera.Business.Services.Interfaces
{
    public interface IBaseService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : class
    {
        Task Create(TModel model);
        Task<bool> Delete(Guid id);
        ValueTask<TModel> GetById(Guid id);
        TEntity OnBeforeCreate(TModel model);
        TEntity OnBeforeUpdate(TModel model);
        Task Update(TModel model);
    }
}