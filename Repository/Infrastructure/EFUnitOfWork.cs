using System;
using System.Data.Entity;

namespace EFRepository.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool _disposed = false;

        public EFUnitOfWork(DbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
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
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    if (_context != null)
                        _context.Dispose();                   
                }                
            }
            _disposed = true;
        }
    }
}