using System;
using System.Data.Entity;

namespace EFRepository.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private bool disposed = false;

        public EFUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        // Implement IDisposable.       
        public void Dispose()
        {
            Dispose(true);
            // Take yourself off the Finalization queue to prevent finalization code for this object from executing a second time.
            GC.SuppressFinalize(this);
        }
       
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    this.Dispose();
                }                
            }
            disposed = true;
        }
    }
}