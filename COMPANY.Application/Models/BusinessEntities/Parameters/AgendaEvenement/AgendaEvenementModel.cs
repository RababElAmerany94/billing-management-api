namespace COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Enums.Parameters;

    public class AgendaEvenementModel : EntityModel<string>
    {
        /// <summary>
        /// the name of agenda événement
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the type of évenement agenda
        /// </summary>
        public AgendaEvenementType Type { get; set; }
    }
}
