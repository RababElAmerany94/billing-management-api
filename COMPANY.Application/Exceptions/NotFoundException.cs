namespace COMPANY.Application.Exceptions
{
    using COMPANY.Domain.Exceptions;
    using System;

    public class NotFoundException : COMPANYException
    {
        public int MessageCode { get; set; }

        public NotFoundException()
        { }

        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string message, int messageCode) : base(message)
        {
            MessageCode = messageCode;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
