namespace COMPANY.Domain.Entities.Parameters
{
    using COMPANY.Domain.Enums.Parameters;
    using System.Collections.Generic;

    public class AgendaEvenement : Entity<string>
    {
        public AgendaEvenement()
        {
            Id = Common.Helpers.IdentityDocument.Generate("AgendaEvenement");
        }

        /// <summary>
        /// the name of agenda événement
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the type of évenement agenda
        /// </summary>
        public AgendaEvenementType Type { get; set; }

        /// <summary>
        /// the list of commercial exchanges type task associate with this entity
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercialsTacheType { get; set; }

        /// <summary>
        /// the list of commercial exchanges type category associate with this entity
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercialsCategorie { get; set; }

        /// <summary>
        /// the list of commercial exchanges type appel associate with this entity
        /// </summary>
        public IEnumerable<EchangeCommercial> EchangeCommercialsTypeAppel { get; set; }

        /// <summary>
        /// the list of commercial exchanges type RDV associate with this entity
        /// </summary>
        public IEnumerable<EchangeCommercial> EchangeCommercialsRdvType { get; set; }

        /// <summary>
        /// the list of commercial exchanges type source RDV associate with this entity
        /// </summary>
        public IEnumerable<EchangeCommercial> EchangeCommercialsSourceRDV { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Name}";
    }
}
