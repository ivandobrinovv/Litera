using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Business.Services
{
    public class BaseService<TEntity, TModel, TRepository> 
        where TEntity : BaseEntity
        where TModel : class
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        // TODO: Configure automapper
        
    }
}
