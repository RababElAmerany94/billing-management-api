namespace COMPANY.Domain.Entities.Parameters
{
    /// <summary>
    /// a class that defines the modele SMS entity
    /// </summary>
    public class ModeleSms : Entity<string>
    {
        public ModeleSms()
        {
            Id = Common.Helpers.IdentityDocument.Generate("ModeleSms");
        }

        /// <summary>
        /// the nom with SMS
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the text with SMS
        /// </summary>
        public string Text { get; set; }

        public override void BuildSearchTerms() 
            => SearchTerms = $"{Name}";
    }
}
