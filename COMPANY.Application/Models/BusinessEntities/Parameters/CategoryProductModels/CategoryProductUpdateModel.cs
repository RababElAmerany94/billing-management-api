namespace COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe category product update model
    /// </summary>
    public class CategoryProductUpdateModel : CategoryProductCreateModel, IEntityUpdateModel<CategoryProduct>
    {
        /// <summary>
        /// update the category product from the current category product Model
        /// </summary>
        /// <param name="entity">the category product entity</param>
        public void Update(CategoryProduct entity)
        {
            entity.Name = Name;
            entity.AccountingCode = AccountingCode;
        }
    }
}
