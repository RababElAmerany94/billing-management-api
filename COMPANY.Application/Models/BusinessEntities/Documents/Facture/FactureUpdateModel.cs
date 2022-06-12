namespace COMPANY.Application.Models.BusinessEntities.Documents.Facture
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Enums;

    /// <summary>
    /// a class describe facture update model
    /// </summary>
    public class FactureUpdateModel : DocumentComptableUpdateModel, IEntityUpdateModel<Facture>
    {
        /// <summary>
        /// the status of facture 
        /// </summary>
        public FactureStatus Status { get; set; }

        /// <summary>
        /// update the facture from the current facture Model
        /// </summary>
        /// <param name="facture">the facture instant to be updated</param>
        public void Update(Facture facture)
        {
            base.Update(facture);
            facture.Status = Status;
        }
    }
}
