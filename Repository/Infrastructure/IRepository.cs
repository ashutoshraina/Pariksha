using System.Linq;

namespace EFRepository.Infrastructure
{
    /// <summary>
    /// Generic interface for the Repository.
    /// </summary>
    /// <typeparam name="T">EntityType T</typeparam>
   public interface IRepository<T>
    {
        T Add(T entity);

        T Remove(T entity);

        T Update(T entity);

        IQueryable<T> Query();        
    }
}