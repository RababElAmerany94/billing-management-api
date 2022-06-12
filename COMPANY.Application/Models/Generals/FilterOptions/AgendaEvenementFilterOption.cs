namespace COMPANY.Application.Models.Generals.FilterOptions
{
    using COMPANY.Domain.Enums.Parameters;

    /// <summary>
    /// a class describe Agenda Evenement filter option
    /// </summary>
    public class AgendaEvenementFilterOption : FilterOption
    {
        /// <summary>
        /// the type of agenda évènement
        /// </summary>
        public AgendaEvenementType? Type { get; set; }

    }
}
