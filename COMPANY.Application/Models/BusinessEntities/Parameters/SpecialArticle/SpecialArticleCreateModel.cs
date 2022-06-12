namespace COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels
{
    /// <summary>
    /// a class describe special article create model
    /// </summary>
    public class SpecialArticleCreateModel
    {
        /// <summary>
        /// the designation of article of oblige
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// the description of article of oblige
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the id of agence
        /// </summary>
        public string AgenceId { get; set; }

    }
}
