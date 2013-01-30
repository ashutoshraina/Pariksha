using System;
using System.Data.Entity;
using System.Linq;

namespace EFRepository.Infrastructure
{
    /// <summary>
    /// A EFRepository represents the repository for performing operations on the
    /// Entity using the EntityFramework.
    /// </summary>
    /// <typeparam name="T">T is the Entity</typeparam>
    public class EFRepository<T> : IRepository<T> where T : class
{
        /// <summary>
        /// This is set in the constructor and provides access to the underlying EntityFramework methods
        /// </summary>
        private DbSet<T> _dbSet;

        /// <summary>
        /// The context for working with the EntityFramework. This is set in the constructor.
        /// </summary>
        private DbContext _dataContext;

        /// <summary>
        /// Constructor which sets the DbContext and the UnitOfwork for the repository to perform actions on.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dataContext"></param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if any of the arguments is null</exception>
        public EFRepository(IUnitOfWork unitOfWork, DbContext dataContext)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork", "unitOfWork cannot be null");
            }

            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext", "dataContext cannot be null");
            }

            var EfUnitOfWork = unitOfWork as EFUnitOfWork;            
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        /// <summary>
        /// Adds the specified Entity to the DbSet of the context.
        /// The Entity is inserted only when UnitOfWork is commited.
        /// </summary>
        /// <param name="item">The Entity to be added</param>
        /// <returns>The added Entity</returns>
        public T Add(T item)
        {
            return _dbSet.Add(item);
        }

        /// <summary>
        /// Removes the specified Entity from the DbSet of the context.
        /// The Entity is removed only when UnitOfWork is commited.
        /// </summary>
        /// <param name="item">The Entity to be removed</param>
        /// <returns>The Entity removed from the underlying DbSet</returns>
        public T Remove(T item)
        {
            return _dbSet.Remove(item);
        }

        /// <summary>
        /// Removes the specified Entity from the DbSet of the context.
        /// The Entity is removed only when UnitOfWork is commited.
        /// </summary>
        /// <param name="item">The Entity to be updated</param>
        /// <returns>the Entity removed from the underlying DbSet</returns>
        public T Update(T item)
        {
            var updated = _dbSet.Attach(item);
            _dataContext.Entry(item).State = EntityState.Modified;
            return updated;
        }

        /// <summary>
        /// Provides the caller with the underlying DbSet.
        /// </summary>
        /// <returns>An IQueryable to run queries against the underlying DbSet</returns>
        public IQueryable<T> Query()
        {
            return _dbSet;
        }

        /// <summary>
        /// Allows the caller to include a specific navigational property in the result set. 
        /// </summary>
        /// <param name="include"></param>
        /// <returns>An IQueryable to run queries against the underlying DbSet with the included Navigational Property
        /// </returns>
        public IQueryable<T> QueryWithInclude(string include)
        {
            return _dbSet.Include(include);
        }
    }
}