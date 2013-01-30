using System;

namespace EFRepository.Infrastructure
{
    /// <summary>
    /// The Interface for implementing a UnitOfWork in the Repository
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
