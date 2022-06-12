namespace COMPANY.Application.Models.BusinessEntities.Parameters.ModeleSms
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Parameters;

    public class ModeleSmsUpdateModel : ModeleSmsCreateModel, IEntityUpdateModel<ModeleSms>
    {
        public void Update(ModeleSms entity)
        {
            entity.Name = Name;
            entity.Text = Text;
        }
    }
}
