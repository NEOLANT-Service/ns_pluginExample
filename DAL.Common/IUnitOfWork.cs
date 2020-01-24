using System;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// Сохранение изменений с поддержкой асинхронности
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();

        /// <summary>
        /// Откат изменений
        /// </summary>
        void Rollback();
    }
}
