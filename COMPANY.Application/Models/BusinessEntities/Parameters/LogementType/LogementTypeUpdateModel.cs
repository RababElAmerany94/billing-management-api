namespace COMPANY.Application.Models.BusinessEntities.Parameters.LogementType
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Parameters;

    public class LogementTypeUpdateModel : LogementTypeCreateModel, IEntityUpdateModel<LogementType>
    {
        public void Update(LogementType entity)
        {
            entity.Name = Name;
        }
    }
}
