using AutoMapper;
using Litera.Business.Services.Interfaces;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Litera.Business.Services
{
    public class BaseService<TEntity, TViewModel, TRepository> : IBaseService<TEntity, TViewModel> where TEntity : BaseEntity
        where TViewModel : class
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

        public virtual async Task<TEntity> OnBeforeCreate(TViewModel model)
        {
            return _mapper.Map<TEntity>(model);
        }

        public virtual async Task Create(TViewModel model)
        {
            var entity = await OnBeforeCreate(model);

            await _repository.CreateAsync(entity);
        }

        public virtual async Task<TEntity> OnBeforeUpdate(TViewModel model)
        {
            return _mapper.Map<TEntity>(model);
        }

        public async virtual Task Update(TViewModel model)
        {
            var entity = await OnBeforeUpdate(model);

            await _repository.UpdateAsync(entity);
        }

        public virtual async ValueTask<TViewModel> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<TViewModel>(entity);
        }

        public virtual async Task<List<TViewModel>> GetAllAsync(Expression<Func<TViewModel, bool>>? filter = null)
        {
            var expression = _mapper.Map<Expression<Func<TEntity, bool>>?>(filter);

            var result = await _repository.GetAllAsync(expression);

            return _mapper.Map<List<TViewModel>>(result);
        }
    }
}
