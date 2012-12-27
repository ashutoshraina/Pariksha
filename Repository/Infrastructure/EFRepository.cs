using System;
using System.Data.Entity;
using System.Linq;

namespace EFRepository.Infrastructure
{
    public class EFRepository<T> : IRepository<T> where T : class
{
        private DbSet<T> _dbSet;
        private DbContext _dataContext;

        public EFRepository(IUnitOfWork unitOfWork, DbContext dataContext)
        {
            var efUnitOfWork = unitOfWork as EFUnitOfWork;
            if (efUnitOfWork == null) throw new EFRepositoryUnitOfWorkException();
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public T Add(T item)
        {
            return _dbSet.Add(item);
        }

        public T Remove(T item)
        {
            return _dbSet.Remove(item);
        }

        public T Update(T item)
        {
            var updated = _dbSet.Attach(item);
            _dataContext.Entry(item).State = EntityState.Modified;
            return updated;
        }

        public IQueryable<T> Query()
        {
            return _dbSet;
        }

        public IQueryable<T> QueryWithInclude(String include)
        {
            return _dbSet.Include(include);
        }
    }
}