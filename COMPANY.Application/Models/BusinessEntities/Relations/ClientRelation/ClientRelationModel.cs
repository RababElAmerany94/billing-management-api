namespace COMPANY.Application.Models.BusinessEntities.Relations.ClientRelation
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.ClientModels;
    using COMPANY.Domain.Enums.ExternalPartners;

    /// <summary>
    /// a class describe client relation model
    /// </summary>
    public class ClientRelationModel: EntityModel<string>
    {
        /// <summary>
        /// the type of relationship
        /// </summary>
        public ClientRelationType Type { get; set; }

        #region relationship

        /// <summary>
        /// the id of client associate
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the client associate
        /// </summary>
        public ClientListModel Client { get; set; }

        #endregion
    }
}
