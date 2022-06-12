namespace COMPANY.Application.Models.BusinessEntitiesModels.UniteModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe unite update model
    /// </summary>
    public class UniteUpdateModel : UniteCreateModel, IEntityUpdateModel<Unite>
    {
        /// <summary>
        /// a method to update unite entity 
        /// </summary>
        /// <param name="unite">the unit entity</param>
        public void Update(Unite unite)
        {
            unite.Name = Name;
            unite.Abbreviation = Abbreviation;
        }
    }

}
