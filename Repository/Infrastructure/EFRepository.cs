using System;
using System.Data.Entity;
using System.Linq;

namespace EFRepository.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T> : IRepository<T> where T : class
{
        /// <summary>
        /// 
        /// </summary>
        private DbSet<T> _dbSet;

        /// <summary>
        /// 
        /// </summary>
        private DbContext _dataContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dataContext"></param>
        public EFRepository(IUnitOfWork unitOfWork, DbContext dataContext)
        {
            var EfUnitOfWork = unitOfWork as EFUnitOfWork;
            if (EfUnitOfWork == null) throw new EFRepositoryUnitOfWorkException();
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Add(T item)
        {
            return _dbSet.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Remove(T item)
        {
            return _dbSet.Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Update(T item)
        {
            var updated = _dbSet.Attach(item);
            _dataContext.Entry(item).State = EntityState.Modified;
            return updated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Query()
        {
            return _dbSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<T> QueryWithInclude(string include)
        {
            return _dbSet.Include(include);
        }
    }
}