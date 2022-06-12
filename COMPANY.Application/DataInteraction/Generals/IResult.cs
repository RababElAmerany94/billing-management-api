//namespace COMPANY.Application.Data
//{
//    using Domain.Exceptions;
//    using Enums;

//    /// <summary>
//    /// an interface that defines a paged result
//    /// </summary>
//    /// <typeparam name="T">the type of the result</typeparam>
//    public interface IPagedResult<T> : IResult<System.Collections.Generic.IEnumerable<T>>
//    {
//        /// <summary>
//        /// the index of the current page
//        /// </summary>
//        int CurrentPage { get; set; }

//        /// <summary>
//        /// the total count of the pages
//        /// </summary>
//        int PageCount { get; set; }

//        /// <summary>
//        /// the page size
//        /// </summary>
//        int PageSize { get; set; }

//        /// <summary>
//        /// the total count of rows
//        /// </summary>
//        int RowCount { get; set; }

//        /// <summary>
//        /// the index of the first row on the page
//        /// </summary>
//        int FirstRowOnPage { get; }

//        /// <summary>
//        /// the index of the last row on the page
//        /// </summary>
//        int LastRowOnPage { get; }
//    }

//    /// <summary>
//    /// an interface to describe a result from a database operation
//    /// </summary>
//    /// <typeparam name="T">the type of the returned result</typeparam>
//    public interface IResult<T> : IResult
//    {
//        /// <summary>
//        /// the result of the operation
//        /// </summary>
//        T Value { get; }
//    }

//    /// <summary>
//    /// an interface to describe a result from a database operation
//    /// </summary>
//    /// <typeparam name="T">the type of the returned result</typeparam>
//    public interface IResult
//    {
//        /// <summary>
//        /// the Status of the result
//        /// </summary>
//        ResultStatus Status { get; }

//        /// <summary>
//        /// get the message associated with this result
//        /// </summary>
//        string Message { get; }

//        /// <summary>
//        /// a code that represent a message, used for multilingual scenario
//        /// </summary>
//        string MessageCode { get; }

//        /// <summary>
//        /// check if the operation associated with this result has produce a value
//        /// </summary>
//        bool HasValue { get; }

//        /// <summary>
//        /// is this Result has raised an error
//        /// </summary>
//        bool HasError { get; }

//        /// <summary>
//        /// the exception instant, if there is an error associated with operation
//        /// if no error this will be null
//        /// </summary>
//        Error Error { get; }
//    }
//}
