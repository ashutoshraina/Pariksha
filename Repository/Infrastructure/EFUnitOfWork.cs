using System.Data.Entity;

namespace EFRepository.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext context;

        public EFUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}