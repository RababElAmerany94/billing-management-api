namespace COMPANY.Application.Models.BusinessEntitiesModels.CategoryDocumentsModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    /// <summary>
    /// a class describe category documents model
    /// </summary>
    public class CategoryDocumentModel : EntityModel<string>
    {
        /// <summary>
        /// the name of document code
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the color code 
        /// </summary>
        public string Color { get; set; }
    }
}
