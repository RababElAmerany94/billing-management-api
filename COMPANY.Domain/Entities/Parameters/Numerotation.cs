namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Enums;

    /// <summary>
    ///  a class that describe an numerotation
    /// </summary>
    public class Numerotation : Entity<string>
    {
        public Numerotation()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Numerotation");
        }

        /// <summary>
        /// the root of the numerotation
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// the date format the numerotation
        /// </summary>
        public DateFormat DateFormat { get; set; }

        /// <summary>
        /// the current counter of numerotation
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        /// the counter length of numerotation
        /// </summary>
        public int? CounterLength { get; set; }

        /// <summary>
        /// the type of numerotation <see cref="NumerotationType"/>
        /// </summary>
        public NumerotationType Type { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence related to this numerotation, could be null
        /// </summary>
        public Agence Agence { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }
}
