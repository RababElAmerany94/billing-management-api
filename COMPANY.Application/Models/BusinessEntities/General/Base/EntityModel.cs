namespace COMPANY.Application.Models.BusinessEntities.General.Base
{
    public class EntityModel<TKey>
    {
        /// <summary>
        /// the id of the entity
        /// </summary>
        public TKey Id { get; set; }
    }
}
