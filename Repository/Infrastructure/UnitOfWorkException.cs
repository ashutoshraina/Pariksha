using System;

namespace EFRepository.Infrastructure
{
    [Serializable]
    public class UnitOfWorkException : Exception
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