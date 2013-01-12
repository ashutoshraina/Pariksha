using System;

namespace EFRepository
{
    [Serializable]
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