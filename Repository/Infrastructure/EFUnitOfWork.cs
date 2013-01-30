using System;
using System.Data.Entity;

namespace EFRepository.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext for the UnitOfWork
        /// </summary>
        private DbContext _context;

        /// <summary>
        /// Private field to check if the context has been disposed
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Constructor with context as parameter to inject the DbContext
        /// </summary>
        /// <param name="context"></param>
        public EFUnitOfWork(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to e called when a UnitOfWork is to be committed.
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        // Implement IDisposable.       
        public void Dispose()
        {
            Dispose(true);

            // Take yourself off the Finalization queue to prevent finalization code for object from executing a second time.
            GC.SuppressFinalize(this);
        }
       
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }                
            }

            _disposed = true;
        }
    }
}