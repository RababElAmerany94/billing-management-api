namespace COMPANY.Presistence.Implementations
{
    using Application.Data.Enums;
    using COMPANY.Application.DataInteraction.Generals;
    using Domain.Exceptions;
    using System;
    using System.Collections.Generic;

    public class PagedResult<TResult> : Result<IEnumerable<TResult>>
    {
        /// <summary>
        /// the constructor with all props initializing
        /// </summary>
        /// <param name="status">the result status</param>
        /// <param name="message">the message associated with the result</param>
        /// <param name="messageCode">the message code associated with the result</param>
        /// <param name="error">the exception associated with this result</param>
        protected PagedResult(
            IEnumerable<TResult> value, int currentPage, int pageCount, int pageSize, int rowCount, ResultStatus status, string message, string messageCode, Error error = null)
            : base(value, status, message, messageCode, error)
        {
            CurrentPage = currentPage;
            PageCount = pageCount;
            PageSize = pageSize;
            RowCount = rowCount;
        }

        /// <summary>
        /// the index of the current page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// the total count of the pages
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// the page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// the total count of rows
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// the index of the first row on the page
        /// </summary>
        public int FirstRowOnPage
        {
            get => (CurrentPage - 1) * PageSize + 1;
        }

        /// <summary>
        /// the index of the last row on the page
        /// </summary>
        public int LastRowOnPage
        {
            get => Math.Min(CurrentPage * PageSize, RowCount);
        }

        public static PagedResult<TResult> Success(IEnumerable<TResult> value, int currentPage, int pageCount, int pageSize, int rowCount, string message = "", string messageCode = "")
            => new PagedResult<TResult>(value, currentPage, pageCount, pageSize, rowCount, ResultStatus.Succeed, message, messageCode, null);

        public new static PagedResult<TResult> Failed(Error error, string message, string messageCode = "")
            => new PagedResult<TResult>(default, 1, 20, 20, 0, ResultStatus.Failed, message, messageCode, error);
    }
}
