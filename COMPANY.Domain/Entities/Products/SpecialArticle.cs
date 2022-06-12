namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class describe special articles for client type <see cref="ClientType.Obliges"/>
    /// </summary>
    public class SpecialArticle : Entity<string>
    {
        public SpecialArticle()
        {
            Id = Common.Helpers.IdentityDocument.Generate("SpecialArticle");
        }

        /// <summary>
        /// the designation of special article
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// the description of special article
        /// </summary>
        public string Description { get; set; }

        #region

        /// <summary>
        /// the id of agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence who own this special article
        /// </summary>
        public Agence Agence { get; set; }

        #endregion

        public override void BuildSearchTerms()
            => SearchTerms = $"{Designation} {Description}";
    }
}
