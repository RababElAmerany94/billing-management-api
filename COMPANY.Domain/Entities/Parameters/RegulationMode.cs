using COMPANY.Domain.Enums.Documents;
using System.Collections.Generic;

namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class describe regulation mode
    /// </summary>
    public class RegulationMode : Entity<string>
    {
        public RegulationMode()
        {
            Id = Common.Helpers.IdentityDocument.Generate("RegulationMode");
        }

        /// <summary>
        /// the name of regulation mode
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// is this regulation mode can modify
        /// </summary>
        public bool IsModify { get; set; }

        #region relations

        /// <summary>
        /// the list of paiements associate with this regulation mode
        /// </summary>
        public ICollection<Paiement> Paiements { get; set; }

        #endregion

        public override void BuildSearchTerms() => SearchTerms = $"{Name}";
    }
}
