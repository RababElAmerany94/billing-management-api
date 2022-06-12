namespace COMPANY.Application.Data
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using Domain.Interfaces;

    public interface IDataAccessFactory
    {
        IDataAccess<TEntity> CreateDataAccess<TEntity>()
            where TEntity : class, IEntity;

        IDataAccess<TEntity, TKey> CreateDataAccess<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>;
    }
}
