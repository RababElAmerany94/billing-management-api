namespace COMPANY.Domain.Entities.Parameters
{
    /// <summary>
    /// a class describe additional fields for installation site
    /// </summary>
    public class ChampSiteInstallation : Entity<string>
    {
        /// <summary>
        /// the name of field
        /// </summary>
        public string Name { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Name}";
    }
}
