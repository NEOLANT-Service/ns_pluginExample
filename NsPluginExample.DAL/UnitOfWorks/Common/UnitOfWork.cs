using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Common;
using Microsoft.EntityFrameworkCore;

namespace NsPluginExample.DAL.UnitOfWorks.Common
{
    /// <summary>
    /// Абстрактная реализация UnitOfWork
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected readonly TContext context;
        private bool disposed = false;

        public UnitOfWork(TContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CommitAsync()
        {
            if (context.ChangeTracker.HasChanges())
                return await context.SaveChangesAsync() > 0;
            return await Task.FromResult(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Освободить ресурсы
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        /// <summary>
        /// Восстановить предыдущее состояние
        /// </summary>
        public void Rollback()
        {
            context
              .ChangeTracker
              .Entries()
              .ToList()
              .ForEach(x => x.Reload());
        }
    }
}
