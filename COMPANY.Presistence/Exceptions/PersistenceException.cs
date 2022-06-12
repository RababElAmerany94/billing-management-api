namespace COMPANY.Presistence.Exceptions
{
    using COMPANY.Domain.Exceptions;
    using System;

    /// <summary>
    /// a class define exception of persistence layer
    /// </summary>
    public class PersistenceException : COMPANYException
    {
        public PersistenceException()
        { }

        public PersistenceException(string message) : base(message)
        { }

        public PersistenceException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
