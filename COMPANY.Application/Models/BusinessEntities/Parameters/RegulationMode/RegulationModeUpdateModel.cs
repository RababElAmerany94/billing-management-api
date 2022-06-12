namespace COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe regulation update model
    /// </summary>
    public class RegulationModeUpdateModel : RegulationModeCreateModel, IEntityUpdateModel<RegulationMode>
    {
        /// <summary>
        /// internal update regulation mode
        /// </summary>
        /// <param name="regulationMode"></param>
        public void Update(RegulationMode regulationMode)
        {
            regulationMode.Name = Name;
        }
    }
}
