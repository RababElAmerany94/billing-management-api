namespace COMPANY.Application.Models.BusinessEntities.Parameters.ChampsSiteInstallation
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    /// <summary>
    /// a class describe model for <see cref="ChampSiteInstallation">
    /// </summary>
    public class ChampSiteInstallationModel : EntityModel<string>
    {
        /// <summary>
        /// the name of field
        /// </summary>
        public string Name { get; set; }
    }
}
