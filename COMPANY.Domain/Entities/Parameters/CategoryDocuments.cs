namespace COMPANY.Domain.Entities.Parameters
{
    /// <summary>
    /// a class describe category documents entity
    /// </summary>
    public class CategoryDocuments : Entity<string>
    {
        public CategoryDocuments()
        {
            Id = Common.Helpers.IdentityDocument.Generate("CategoryDocuments");
        }

        /// <summary>
        /// the name of category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the document code
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// the search builder
        /// </summary>
        public override void BuildSearchTerms() => SearchTerms = $"{Name}";
    }
}
