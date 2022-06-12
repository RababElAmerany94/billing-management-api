namespace COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType
{
    using COMPANY.Domain.Enums.Parameters;

    public class AgendaEvenementCreateModel
    {
        public string Name { get; set; }

        /// <summary>
        /// the type of évenement agenda
        /// </summary>
        public AgendaEvenementType Type { get; set; }
    }
}
