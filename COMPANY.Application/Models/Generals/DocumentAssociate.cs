namespace COMPANY.Application.Models.General
{
    using COMPANY.Domain.Enums;
    using System;

    /// <summary>
    /// a class describe document associate
    /// </summary>
    public class DocumentAssociate
    {
        /// <summary>
        /// the id of document
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the type of document
        /// </summary>
        public DocType Type { get; set; }

        /// <summary>
        /// the date of creation
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// the reference of document
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the total TTC of document
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the status of document
        /// </summary>
        public int Status { get; set; }
    }
}
