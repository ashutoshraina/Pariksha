using System;

namespace EFRepository
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