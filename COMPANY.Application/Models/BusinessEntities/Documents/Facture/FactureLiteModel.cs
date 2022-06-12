namespace COMPANY.Application.Models.BusinessEntities.Documents.Facture
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Enums.Documents;

    public class FactureLiteModel : EntityModel<string>
    {
        /// <summary>
        /// the reference of accounting document
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the type of facture
        /// </summary>
        public FactureType Type { get; set; }

        /// <summary>
        /// total hors taxes of accounting document
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// total TTC of this accounting document
        /// </summary>
        public decimal TotalTTC { get; set; }
    }
}
