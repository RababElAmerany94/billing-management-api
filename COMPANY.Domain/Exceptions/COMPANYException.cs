using System;

namespace COMPANY.Domain.Exceptions
{
    /// <summary>
    /// the base exception Class for all Application Exceptions
    /// </summary>
    [Serializable]
    public class COMPANYException : Exception
    {
        public COMPANYException() { }

        public COMPANYException(string message) 
            : base(message) { }

        public COMPANYException(string message, Exception inner) 
            : base(message, inner) { }

        protected COMPANYException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}
