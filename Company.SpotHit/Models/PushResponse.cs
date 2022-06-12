namespace Company.SpotHit.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// a class describe receive push response
    /// </summary>
    public class PushResponse
    {
        /// <summary>
        /// Identifiant unique
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Numéro de téléphone de l'émetteur
        /// </summary>
        [JsonProperty("numero")]
        public string Numero { get; set; }

        /// <summary>
        /// Timestamp date d'envoi de la réponse
        /// </summary>
        [JsonProperty("date")]
        public long Date { get; set; }

        /// <summary>
        /// Contenu du message réponse
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Identifiant unique du message source
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
