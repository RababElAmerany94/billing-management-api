namespace COMPANY.Domain.Entities
{
    using System;

    /// <summary>
    /// a class describe an accounting period
    /// </summary>
    public class PeriodeComptable : Entity<string>
    {
        public PeriodeComptable()
        {
            Id = Common.Helpers.IdentityDocument.Generate("PeriodeComptable");
        }

        /// <summary>
        /// start date of accounting period
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// period of accounting period (12,16 months)
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// closing date of accounting period
        /// </summary>
        public DateTime? DateCloture { get; set; }

        /// <summary>
        /// is the accounting period closed
        /// </summary>
        public bool IsClose { get; set; }

        /// <summary>
        /// the id of the agence of this accounting period
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence of this accounting period
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// the id of the user of this accounting period
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the user associate of this accounting period
        /// </summary>
        public User User { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }
}
