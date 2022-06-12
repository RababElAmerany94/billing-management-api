namespace COMPANY.Application.Models.BusinessEntities.Documents.Avoir
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;

    /// <summary>
    /// a class describe avoir model
    /// </summary>
    public class AvoirModel : DocumentComptableModel
    {
        /// <summary>
        /// the status of avoir 
        /// </summary>
        public AvoirStatus Status { get; set; }

        /// <summary>
        /// the type creation of avoir (independent or payment)
        /// </summary>
        public AvoirCreateType Type { get; set; }

        /// <summary>
        /// the id of facture associate with this avoir
        /// </summary>
        public string FactureId { get; set; }

        /// <summary>
        /// the facture associate with this avoir
        /// </summary>
        public FactureModel Facture { get; set; }
    }
}
