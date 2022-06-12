namespace COMPANY.Application.Exceptions
{
    using COMPANY.Domain.Exceptions;
    using System;

    public class UnAcceptableRequestException : COMPANYException
    {
        public int MessageCode { get; set; }

        public UnAcceptableRequestException()
        { }

        public UnAcceptableRequestException(string message) : base(message)
        { }

        public UnAcceptableRequestException(string message, int messageCode) : base(message)
        {
            MessageCode = messageCode;
        }

        public UnAcceptableRequestException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
