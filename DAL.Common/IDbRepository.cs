using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Common
{
    /// <summary>
    /// Абстракция репозитория БД
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IDbRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// Вернет сущность по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Вернет список всех сущностей из хранилища
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Произведет поиск сущностей в хранилище по критерию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Добавит новую сущность в хранилище
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Добавит несколько сущностей в хранилище
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Помещает сущность как измененую
        /// </summary>
        /// <param name="entity"></param>
        void Modify(TEntity entity);

        /// <summary>
        /// Помечает сущность как удаленную
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Помечает список сущностей как удаленные
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Помечает все элементы репозитория как удаленные
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// Помечает сущность как удаленную, находя ее в хранилище по ключу
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);

        /// <summary>
        /// Помечает все элементы репозитория как удаленные
        /// </summary>
        void RemoveAllAsync();

        //Асинхронные запросы

        /// <summary>
        /// Вернет сущность по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Вернте все сущности из хранилища
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Вернет количество записией
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

        /// <summary>
        /// Вернет наличие элементов в хранилище по условию, переданому в предикате
        /// </summary>
        /// <param name="predicate">условие поиска элементов</param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Вернет наличие элементов в хранилище по условию, переданому в предикате
        /// </summary>
        /// <param name="predicate">условие поиска элементов</param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
