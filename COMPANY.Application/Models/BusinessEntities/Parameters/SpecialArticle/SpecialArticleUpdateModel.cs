namespace COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe special article update model
    /// </summary>
    public class SpecialArticleUpdateModel : SpecialArticleCreateModel, IEntityUpdateModel<SpecialArticle>
    {
        /// <summary>
        /// update special article
        /// </summary>
        /// <param name="specialArticle">the special article entity</param>
        public void Update(SpecialArticle specialArticle)
        {
            specialArticle.Designation = Designation;
            specialArticle.Description = Description;
        }
    }

}
