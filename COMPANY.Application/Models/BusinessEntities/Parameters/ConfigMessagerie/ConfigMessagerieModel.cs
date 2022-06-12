namespace COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    public class ConfigMessagerieModel :EntityModel<string>
    {

        /// <summary>
        /// the parameters username of Config MessagerieModel
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// the parameters password of Config MessagerieModel
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// the parameters serveur of Config MessagerieModel
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// the parameters port of Config MessagerieModel
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// the parameters SSL of Config MessagerieModel
        /// </summary>
        public bool Ssl { get; set; }

        /// <summary>
        /// The id of agence associate with this config
        /// </summary>
        public string AgenceId { get; set; }
    }
}
