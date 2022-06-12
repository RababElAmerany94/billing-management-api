namespace COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Parameters;

    public class AgendaEvenementUpdateModel : AgendaEvenementCreateModel, IEntityUpdateModel<AgendaEvenement>
    {
        public void Update(AgendaEvenement entity)
        {
            entity.Name = Name;
        }
    }
}
