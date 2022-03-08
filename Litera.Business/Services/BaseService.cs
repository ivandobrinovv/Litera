using AutoMapper;
using Litera.Business.Services.Interfaces;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Business.Services
{
    public class BaseService<TEntity, TModel, TRepository> : IBaseService<TEntity, TModel> where TEntity : BaseEntity
        where TModel : class
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;

        public BaseService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public virtual TEntity OnBeforeCreate(TModel model)
        {
            return _mapper.Map<TEntity>(model);
        }

        public virtual async Task Create(TModel model)
        {
            var entity = OnBeforeCreate(model);

            await _repository.CreateAsync(entity);
        }

        public virtual TEntity OnBeforeUpdate(TModel model)
        {
            return _mapper.Map<TEntity>(model);
        }

        public async virtual Task Update(TModel model)
        {
            var entity = OnBeforeUpdate(model);

            await _repository.UpdateAsync(entity);
        }

        public virtual async ValueTask<TModel> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<TModel>(entity);
        }
    }
}
