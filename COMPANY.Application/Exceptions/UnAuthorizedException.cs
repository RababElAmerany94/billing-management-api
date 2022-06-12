namespace COMPANY.Application.Exceptions
{
    using COMPANY.Domain.Exceptions;
    using System;

    public class UnAuthorizedException : COMPANYException
    {
        public UnAuthorizedException()
        { }

        public UnAuthorizedException(string message) : base(message)
        { }

        public UnAuthorizedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
