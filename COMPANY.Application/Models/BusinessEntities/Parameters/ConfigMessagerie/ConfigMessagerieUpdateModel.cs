namespace COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// the class that represent the update model for the ConfigMessagerie
    /// </summary>
    public class ConfigMessagerieUpdateModel : ConfigMessagerieCreateModel, IEntityUpdateModel<ConfigMessagerie>
    {
        /// <summary>
        /// update document parameters
        /// </summary>
        /// <param name="ConfigMessagerie"></param>
        public void Update(ConfigMessagerie ConfigMessagerie)
        {
            ConfigMessagerie.Password = Password;
            ConfigMessagerie.Username = Username;
            ConfigMessagerie.Server = Server;
            ConfigMessagerie.Ssl = Ssl;
            ConfigMessagerie.Port = Port;
        }
    }
}
