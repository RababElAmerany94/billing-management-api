namespace COMPANY.Domain.Enums.Documents
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe payment entity
    /// </summary>
    public class Paiement : Entity<string>, IRecordable, IFollowAgence
    {
        public Paiement()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Paiement");

            Historique = new HashSet<ChangesHistory>();
        }

        /// <summary>
        /// the type of payment
        /// </summary>
        public PaiementType Type { get; set; }

        /// <summary>
        /// the amount of payment
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// the date of payment
        /// </summary>
        public DateTime DatePaiement { get; set; }

        /// <summary>
        /// the description of payment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the history of payment
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// is this payment comptabilise
        /// </summary>
        public bool Comptabilise { get; set; }

        #region relations

        /// <summary>
        /// the id of bank account associate with this payment
        /// </summary>
        public string BankAccountId { get; set; }

        /// <summary>
        /// the bank account associate with this payment
        /// </summary>
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// the id of regulation mode associate with this payment 
        /// </summary>
        public string RegulationModeId { get; set; }

        /// <summary>
        /// the regulation mode associate with this payment 
        /// </summary>
        public RegulationMode RegulationMode { get; set; }

        /// <summary>
        /// the id of avoir associate with this payment 
        /// </summary>
        public string AvoirId { get; set; }

        /// <summary>
        /// the id of avoir associate with this payment 
        /// </summary>
        public Avoir Avoir { get; set; }

        /// <summary>
        /// the id of agence associate with this payment 
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence associate this payment
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// list of facture paiements
        /// </summary>
        public ICollection<FacturePaiement> FacturePaiements { get; set; }

        /// <summary>
        /// the list of paiements associate with this avoir
        /// </summary>
        public ICollection<Paiement> Paiements { get; set; }

        #endregion

        public override void BuildSearchTerms() => SearchTerms = $"{Description}";
    }
}
