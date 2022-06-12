namespace COMPANY.Application.Models.BusinessEntities.Parameters.TypeChauffage
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Parameters;

    public class TypeChauffageUpdateModel : TypeChauffageCreateModel, IEntityUpdateModel<TypeChauffage>
    {
        public void Update(TypeChauffage entity)
        {
            entity.Name = Name;
        }
    }
}
