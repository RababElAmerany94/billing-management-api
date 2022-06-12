namespace COMPANY.Application.DataInteraction.Generals
{
    using Application.Data.Enums;
    using Domain.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// the base result class
    /// </summary>
    public class Result
    {
        /// <summary>
        /// the constructor with all props initializing
        /// </summary>
        /// <param name="status">the result status</param>
        /// <param name="message">the message associated with the result</param>
        /// <param name="messageCode">the message code associated with the result</param>
        /// <param name="error">the exception associated with this result</param>
        protected Result(ResultStatus status, string message, string messageCode, Error error = null)
        {
            Status = status;
            Message = message;
            MessageCode = messageCode;
            Error = error;
        }

        /// <summary>
        /// the Status of the result
        /// </summary>
        public ResultStatus Status { get; }

        /// <summary>
        /// get the message associated with this result, in case of an error
        /// this property will hold the error description
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// a code that represent a message, used for multilingual scenario
        /// </summary>
        public string MessageCode { get; }

        /// <summary>
        /// check if the operation associated with this result has produce a value
        /// </summary>
        public virtual bool HasValue { get => false; }

        /// <summary>
        /// is result success
        /// </summary>
        public virtual bool IsSuccess => Status == ResultStatus.Succeed;

        /// <summary>
        /// is this Result has raised an error
        /// </summary>
        public bool HasError { get => !(Error is null); }

        /// <summary>
        /// the exception instant, if there is an error associated with operation
        /// if no error this will be null
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// get the string representation of the object
        /// </summary>
        /// <returns>the string value</returns>
        public override string ToString()
            => $"Status: {Status}, HasValue: {HasValue}, HasError: {HasError}";

        public static Result Success(string message, string messageCode = "")
           => new Result(ResultStatus.Succeed, message, messageCode, null);

        public static Result Failed(Error error, string message, string messageCode = "")
            => new Result(ResultStatus.Failed, message, messageCode, error);
    }

    /// <summary>
    /// the result class with a value property
    /// </summary>
    public class Result<TResult> : Result
    {
        /// <summary>
        /// the constructor with all props initializing
        /// </summary>
        /// <param name="value">the value</param>
        /// <param name="status">the result status</param>
        /// <param name="message">the message associated with the result</param>
        /// <param name="messageCode">the message code associated with the result</param>
        /// <param name="Error">the exception associated with this result</param>
        protected Result(TResult value, ResultStatus status, string message, string messageCode, Error Error = null)
            : base(status, message, messageCode, Error)
        {
            Value = value;
        }

        /// <summary>
        /// check if the operation associated with this result has produce a value
        /// </summary>
        public override bool HasValue
            => !EqualityComparer<TResult>.Default.Equals(Value, default);

        /// <summary>
        /// the result of the operation
        /// </summary>
        public TResult Value { get; private set; }

        /// <summary>
        /// set the value
        /// </summary>
        /// <param name="value">the value to be set</param>
        public void SetValue(TResult value) => Value = value;

        public static Result<TResult> Success(TResult value, string message = "", string messageCode = "")
           => new Result<TResult>(value, ResultStatus.Succeed, message, messageCode, null);

        public static Result<TResult> Failed(TResult value, Error error, string message, string messageCode = "")
            => new Result<TResult>(value, ResultStatus.Failed, message, messageCode, error);
    }
}
