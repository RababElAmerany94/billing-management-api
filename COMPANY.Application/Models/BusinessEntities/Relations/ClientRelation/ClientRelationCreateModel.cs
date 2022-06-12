namespace COMPANY.Application.Models.BusinessEntities.Relations.ClientRelation
{
    using COMPANY.Domain.Enums.ExternalPartners;

    /// <summary>
    /// a class describe create relation client model
    /// </summary>
    public class ClientRelationCreateModel
    {
        /// <summary>
        /// the id of entity if exists
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the type of relationship
        /// </summary>
        public ClientRelationType Type { get; set; }

        #region relationship

        /// <summary>
        /// the id of client associate
        /// </summary>
        public string ClientId { get; set; }

        #endregion
    }
}
