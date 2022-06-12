namespace COMPANY.Domain.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// a class describe source du lead entity
    /// </summary>
    public class SourceDuLead : Entity<string>
    {
        public SourceDuLead()
        {
            Id = Common.Helpers.IdentityDocument.Generate("SourceDuLead");
        }

        /// <summary>
        /// the name of source du lead
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// list of clients associate with this source du lead
        /// </summary>
        public IEnumerable<Client> Clients { get; set; }

        /// <summary>
        /// list of dossier associate with this source du lead
        /// </summary>
        public IEnumerable<Dossier> Dossiers { get; set; }

        /// <summary>
        /// the search builder
        /// </summary>
        public override void BuildSearchTerms() => SearchTerms = $"{Name}";
    }
}
