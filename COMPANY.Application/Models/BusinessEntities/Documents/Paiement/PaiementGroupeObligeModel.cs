namespace COMPANY.Application.Models.BusinessEntities.Documents.Paiement
{
    using System;

    public class PaiementGroupeObligeModel
    {
        /// <summary>
        /// the date of payment
        /// </summary>
        public DateTime DatePaiement { get; set; }

        /// <summary>
        /// the description of payment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the id of bank account associate with this payment
        /// </summary>
        public string BankAccountId { get; set; }

        /// <summary>
        /// the id of regulation mode associate with this payment 
        /// </summary>
        public string RegulationModeId { get; set; }

        /// <summary>
        /// the fichier excel on base64
        /// </summary>
        public string FichePaiement { get; set; }

        /// <summary>
        /// the id of oblige
        /// </summary>
        public string PrimeCeeId { get; set; }
    }
}
