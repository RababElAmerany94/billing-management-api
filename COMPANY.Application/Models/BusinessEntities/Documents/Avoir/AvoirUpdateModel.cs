namespace COMPANY.Application.Models.BusinessEntities.Documents.Avoir
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Enums.Documents;

    /// <summary>
    /// a class describe avoir update model
    /// </summary>
    public class AvoirUpdateModel : DocumentComptableUpdateModel, IEntityUpdateModel<Avoir>
    {
        /// <summary>
        /// the status of avoir 
        /// </summary>
        public AvoirStatus Status { get; set; }

        public void Update(Avoir entity)
        {
            base.Update(entity);
            entity.Status = Status;
        }
    }
}
