namespace COMPANY.Application.Models.BusinessEntities.Parameters.ChampsSiteInstallation
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Parameters;

    /// <summary>
    /// a class describe update model for <see cref="ChampSiteInstallation">
    /// </summary>
    public class ChampSiteInstallationUpdateModel : ChampSiteInstallationCreateModel, IEntityUpdateModel<ChampSiteInstallation>
    {
        public void Update(ChampSiteInstallation entity)
        {
            entity.Name = Name;
        }
    }
}
