namespace COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    /// <summary>
    /// a class describe regulation mode
    /// </summary>
    public class RegulationModeModel : EntityModel<string>
    {
        /// <summary>
        /// the name of regulation mode
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// is this regulation mode can modify
        /// </summary>
        public bool IsModify { get; set; }
    }
}
