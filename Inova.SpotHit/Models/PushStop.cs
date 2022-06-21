namespace Inova.SpotHit.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// a class describe receive push stop
    /// </summary>
    public class PushStop
    {
        /// <summary>
        /// Identifiant unique
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Numéro de téléphone de l'émetteur (peut-être vide si le champs email est renseigné)
        /// </summary>
        [JsonProperty("numero")]
        public string Numero { get; set; }

        /// <summary>
        /// Email de l'émetteur (peut-être vide si le champs numero est renseigné)
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Timestamp date d'envoi de la réponse
        /// </summary>
        [JsonProperty("date_envoi")]
        public long DateEnvoi { get; set; }

        /// <summary>
        /// Identifiant unique du message source
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; set; }
    }
}
