namespace COMPANY.Application.Models.BusinessEntitiesModels.CategoryDocumentsModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Parameters;

    public class CategoryDocumentUpdateModel : CategoryDocumentCreateModel, IEntityUpdateModel<CategoryDocuments>
    {
        /// <summary>
        /// update the category documents from the current category documents Model
        /// </summary>
        /// <param name="categoryDocuments">the category documents entity</param>
        public void Update(CategoryDocuments categoryDocuments)
        {
            categoryDocuments.Color = Color;
            categoryDocuments.Name = Name;
        }
    }
}
