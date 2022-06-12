namespace COMPANY.Application.Models.BusinessEntities.Parameters.SourceDuLead
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe Source Du Lead update model
    /// </summary>
    public class SourceDuLeadUpdateModel : SourceDuLeadCreateModel, IEntityUpdateModel<SourceDuLead>
    {
        /// <summary>
        /// update the Source Du Lead from the current Source Du Lead Model
        /// </summary>
        /// <param name="entity">the Source Du Lead entity</param>
        public void Update(SourceDuLead entity)
        {
            entity.Name = Name;
        }
    }
}
