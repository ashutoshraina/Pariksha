using System;
using System.Data.Entity;

namespace EFRepository.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        private DbContext _context;

        /// <summary>
        /// 
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EFUnitOfWork(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
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
                        _context.Dispose();                   
                }                
            }
            _disposed = true;
        }
    }
}