namespace COMPANY.Domain.Entities.Relations
{
    /// <summary>
    /// a class describe relation between clients and commercials
    /// </summary>
    public class ClientCommercial : Entity<string>
    {
        /// <summary>
        /// the id of commercial
        /// </summary>
        public string CommercialId { get; set; }

        /// <summary>
        /// the commercials
        /// </summary>
        public User Commercial { get; set; }

        /// <summary>
        /// the id of client
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the client
        /// </summary>
        public Client Client { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
