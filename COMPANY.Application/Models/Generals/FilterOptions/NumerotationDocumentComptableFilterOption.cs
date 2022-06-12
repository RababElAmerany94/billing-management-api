namespace COMPANY.Application.Models.GeneralModels.PagingModels
{
    using COMPANY.Application.Enums;
    using System;

    /// <summary>
    /// a class describe numeration document filter option
    /// </summary>
    public class NumerotationDocumentComptableFilterOption
    {
        /// <summary>
        /// the date of creation
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// the type of numerotation
        /// </summary>
        public DocumentComptableType Type { get; set; }
    }
}
