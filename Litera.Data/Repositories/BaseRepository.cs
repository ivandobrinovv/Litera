﻿using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Litera.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly LiteraDbContext context;
        
        public BaseRepository(LiteraDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            var set = context.Set<T>().AsQueryable();

            if (filter != null)
            {
                set = set.Where(filter);
            }

            return await set.ToListAsync();
        }

        public virtual async ValueTask<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {entity.Id}");
            }

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException($"There is no such {typeof(T)} with id: {id}");
            }

            context.Set<T>().Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
