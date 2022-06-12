namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class describe Config_Messagerie entity
    /// </summary>
    public class ConfigMessagerie : Entity<string>
    {
        public ConfigMessagerie()
        {
            Id = Common.Helpers.IdentityDocument.Generate("ConfigMessagerie");
        }

        /// <summary>
        /// the parameters id of config_messagerie
        /// </summary>
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

        /// <summary>
        /// the agence associate with this config
        /// </summary>
        public Agence Agence { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }
}
