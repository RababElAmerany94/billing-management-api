namespace COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis
{
    using COMPANY.Domain.Enums.General;

    public class FactureDevisCreateModel
    {
        /// <summary>
        /// the montant devis
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// the type montant
        /// </summary>
        public MontantType MontantType { get; set; }

        #region relations

        /// <summary>
        /// the id of devis associate with this class
        /// </summary>
        public string DevisId { get; set; }

        #endregion
    }
}
