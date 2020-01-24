using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Common;
using Microsoft.EntityFrameworkCore;

namespace NsPluginExample.DAL.Repositories.Common
{
    public abstract class DbRepository<TEntity, TKey> : IDbRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext context;

        #region Constructor

        public DbRepository(
            DbContext context
            )
        {
            this.context = context;
        }

        #endregion

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        public void Modify(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
                context.Set<TEntity>().Remove(entity);
        }

        public void Remove(TKey id)
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
            }
        }

        public Task RemoveAsync(TEntity entity)
        {
            return Task.FromResult(context.Set<TEntity>().Remove(entity));
        }

        public async Task RemoveAsync(TKey id)
        {
            TEntity entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                context.Set<TEntity>().RemoveRange(entities);
            }
        }

        public void RemoveAll()
        {
            foreach (var e in context.Set<TEntity>())
            {
                context.Entry(e).State = EntityState.Deleted;
            }
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task RemoveAllAsync()
        {
            RemoveAll();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            return context.Set<TEntity>().CountAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().AnyAsync(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Any(predicate);
        }

        void IDbRepository<TEntity, TKey>.RemoveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
