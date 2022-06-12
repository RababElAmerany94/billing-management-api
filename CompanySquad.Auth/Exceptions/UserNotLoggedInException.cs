namespace Microsoft.AspNetCore.Authentication
{
    [System.Serializable]
    public class UserNotLoggedInExceptionException : System.Exception
    {
        public UserNotLoggedInExceptionException() { }
        public UserNotLoggedInExceptionException(string message) : base(message) { }
        public UserNotLoggedInExceptionException(string message, System.Exception inner) : base(message, inner) { }
        protected UserNotLoggedInExceptionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
