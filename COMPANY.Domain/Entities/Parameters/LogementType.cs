namespace COMPANY.Domain.Entities.Parameters
{
    using System.Collections.Generic;

    /// <summary>
    /// the type of logement
    /// </summary>
    public class LogementType : Entity<string>
    {
        public LogementType()
        {
            Id = Common.Helpers.IdentityDocument.Generate("LogementType");
        }

        /// <summary>
        /// the name of Logement
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// list of clients associate with this logemement type
        /// </summary>
        public IEnumerable<Client> Clients { get; set; }

        /// <summary>
        /// list of dossier associate with this logemement type
        /// </summary>
        public IEnumerable<Dossier> Dossiers { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Name}";
    }
}
