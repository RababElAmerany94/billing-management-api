namespace COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels
{
    /// <summary>
    /// a class describe regulation mode create model
    /// </summary>
    public class RegulationModeCreateModel
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
