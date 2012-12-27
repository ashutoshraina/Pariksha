using System;
using System.Linq;

namespace EFRepository.Infrastructure
{
   public interface IRepository<T>
    {
        T Add(T entity);
        T Remove(T entity);
        T Update(T entity);
        IQueryable<T> Query();
        IQueryable<T> QueryWithInclude(String include);
    }
}