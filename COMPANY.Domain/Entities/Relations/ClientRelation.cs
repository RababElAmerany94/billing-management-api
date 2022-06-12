namespace COMPANY.Domain.Entities.Relations
{
    using COMPANY.Domain.Enums.ExternalPartners;

    /// <summary>
    /// a class describe relation between clients
    /// </summary>
    public class ClientRelation : Entity<string>
    {
        /// <summary>
        /// the type of relationship
        /// </summary>
        public ClientRelationType Type { get; set; }

        #region relationship

        /// <summary>
        /// the id of client associate
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the client associate
        /// </summary>
        public Client Client { get; set; }

        #endregion

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
