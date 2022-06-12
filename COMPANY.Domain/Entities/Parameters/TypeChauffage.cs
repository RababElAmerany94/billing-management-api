using System.Collections.Generic;

namespace COMPANY.Domain.Entities.Parameters
{
    /// <summary>
    /// the type de chauffage
    /// </summary>
    public class TypeChauffage : Entity<string>
    {
        public TypeChauffage()
        {
            Id = Common.Helpers.IdentityDocument.Generate("TypeChauffage");
        }

        /// <summary>
        /// the name of type de chauffage
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// list of clients associate with this type de chauffage
        /// </summary>
        public IEnumerable<Client> Clients { get; set; }

        /// <summary>
        /// list of dossier associate with this type de chauffage
        /// </summary>
        public IEnumerable<Dossier> Dossiers { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Name}";
    }
}
