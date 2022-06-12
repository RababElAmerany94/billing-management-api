namespace COMPANY.Application.Models.BusinessEntitiesModels.UniteModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    /// <summary>
    /// a class describe unite model
    /// </summary>
    public class UniteModel : EntityModel<string>
    {
        /// <summary>
        /// the name of unite
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the abbreviation of unite
        /// </summary>
        public string Abbreviation { get; set; }
    }
}
