namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class describe unite mesure 
    /// </summary>
    public class Unite : Entity<string>
    {
        public Unite()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Unite");
        }

        /// <summary>
        /// the name of unite
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the abbreviation of unite
        /// </summary>
        public string Abbreviation { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"{Name}";
    }
}
