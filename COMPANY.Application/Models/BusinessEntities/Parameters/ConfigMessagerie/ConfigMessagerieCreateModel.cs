namespace COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels
{
    public class ConfigMessagerieCreateModel
    {

        public string Username { get; set; }

        /// <summary>
        /// the parameters password of config_messagerie
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// the parameters serveur of config_messagerie
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// the parameters port of config_messagerie
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// the parameters ssl of config_messagerie
        /// </summary>

        public bool Ssl { get; set; }

        /// <summary>
        /// The id of agence associate with this config
        /// </summary>
        public string AgenceId { get; set; }

    }
}
