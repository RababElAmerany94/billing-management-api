namespace COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    /// <summary>
    /// a class describe category product model
    /// </summary>
    public class CategoryProductModel : EntityModel<string>
    {
        /// <summary>
        /// the name of type of task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the accounting code 
        /// </summary>
        public string AccountingCode { get; set; }
    }
}
