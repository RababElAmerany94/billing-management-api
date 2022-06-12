namespace COMPANY.Domain.Entities.Documents
{
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe avoir entity
    /// </summary>
    public class Avoir : DocumentComptable
    {
        public Avoir() : base()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Avoir");
        }

        /// <summary>
        /// the status of avoir 
        /// </summary>
        public AvoirStatus Status { get; set; }

        /// <summary>
        /// the type creation of avoir (independent or payment)
        /// </summary>
        public AvoirCreateType Type { get; set; }

        #region relations

        /// <summary>
        /// the id of facture associate with this avoir
        /// </summary>
        public string FactureId { get; set; }

        /// <summary>
        /// the facture associate with this avoir
        /// </summary>
        public Facture Facture { get; set; }

        /// <summary>
        /// the list of paiements associate with this avoir
        /// </summary>
        public ICollection<Paiement> Paiements { get; set; }

        #endregion
    }
}
