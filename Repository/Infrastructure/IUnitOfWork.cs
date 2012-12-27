using System;

namespace EFRepository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
