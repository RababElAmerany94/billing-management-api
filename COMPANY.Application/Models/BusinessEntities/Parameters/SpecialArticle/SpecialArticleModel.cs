namespace COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    /// <summary>
    /// a class describe special article model
    /// </summary>
    public class SpecialArticleModel : EntityModel<string>
    {
        /// <summary>
        /// the designation of special article
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// the description of special article
        /// </summary>
        public string Description { get; set; }

        #region

        /// <summary>
        /// the id of agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence who own this special article
        /// </summary>
        public AgenceModel Agence { get; set; }

        #endregion
    }
}
