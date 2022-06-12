namespace COMPANY.Application.Models.BusinessEntities.Relations.ClientCommercial
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;

    /// <summary>
    /// a class describe Client Commercial model
    /// </summary>
    public class ClientCommercialModel : EntityModel<string>
    {
        /// <summary>
        /// the id of commercial
        /// </summary>
        public string CommercialId { get; set; }

        /// <summary>
        /// the commercials
        /// </summary>
        public UserLiteModel Commercial { get; set; }

        /// <summary>
        /// the id of client
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the client
        /// </summary>
        public ClientModel Client { get; set; }
    }
}
