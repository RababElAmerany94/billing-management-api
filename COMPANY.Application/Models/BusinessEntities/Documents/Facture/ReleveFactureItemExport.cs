namespace COMPANY.Application.Models.BusinessEntities.Documents.Facture
{
    using System;

    /// <summary>
    /// a class describe releve facture item
    /// </summary>
    public class ReleveFactureItemExport
    {
        /// <summary>
        /// the date of creation of facture
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// the reference of facture
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the total TTC of facture
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the rest to pay
        /// </summary>
        public decimal RestToPay { get; set; }
    }
}
