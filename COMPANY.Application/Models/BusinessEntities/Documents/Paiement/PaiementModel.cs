namespace COMPANY.Application.Models.BusinessEntities.Documents.Paiement
{
    using COMPANY.Application.Models.BusinessEntities.Documents.Avoir;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels;
    using COMPANY.Application.Models.General;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe payment model
    /// </summary>
    public class PaiementModel : EntityModel<string>
    {
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

        /// <summary>
        /// the id of bank account associate with this payment
        /// </summary>
        public string BankAccountId { get; set; }

        /// <summary>
        /// the bank account associate with this payment
        /// </summary>
        public BankAccountModel BankAccount { get; set; }

        /// <summary>
        /// the id of regulation mode associate with this payment 
        /// </summary>
        public string RegulationModeId { get; set; }

        /// <summary>
        /// the regulation mode associate with this payment 
        /// </summary>
        public RegulationModeModel RegulationMode { get; set; }

        /// <summary>
        /// the id of avoir associate with this payment 
        /// </summary>
        public string AvoirId { get; set; }

        /// <summary>
        /// the id of avoir associate with this payment 
        /// </summary>
        public AvoirModel Avoir { get; set; }

        /// <summary>
        /// the id of agence associate with this payment 
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence associate this payment
        /// </summary>
        public AgenceModel Agence { get; set; }

        /// <summary>
        /// list of facture paiements
        /// </summary>
        public ICollection<FacturePaiementModel> FacturePaiements { get; set; }

        /// <summary>
        /// list of documents associates.
        /// </summary>
        public ICollection<DocumentAssociate> DocumentAssociates { get; set; } = new List<DocumentAssociate>();
    }
}
