using System;

namespace EFRepository
{
    public class EFRepositoryUnitOfWorkException : Exception
    {
        public override string Message
        {
            get
            {
                return "The parameter must be EFUnitOfWork";
            }
        }
    }
}
