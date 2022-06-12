namespace COMPANY.Application.Models.BusinessEntities.General.Base
{
    public interface IEntityUpdateModel<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }
}
