using System;
using System.Data.Entity;

namespace EFRepository.Infrastructure
{
    /// <summary>
    /// Represents an IUnitOfWork for Entity Framework
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext for the UnitOfWork
        /// </summary>
        private DbContext _context;

        /// <summary>
        /// Private field to check if the context has been disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of EfUnitOfWork <see cref="EFUnitOfWork"/>
        /// </summary>
        /// <param name="context">DbContex for the UnitOfWork</param>
        public EFUnitOfWork(DbContext context)
        {
            if (context == null)
            {
                throw new UnitOfWorkException();
            }

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