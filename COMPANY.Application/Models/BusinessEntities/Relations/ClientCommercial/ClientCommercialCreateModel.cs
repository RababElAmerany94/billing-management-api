namespace COMPANY.Application.Models.BusinessEntities.Relations.ClientCommercial
{
    /// <summary>
    /// a class describe create relation client model with commercial
    /// </summary>
    public class ClientCommercialCreateModel
    {
        /// <summary>
        /// the id of entity if exists
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the id of commercial entity if exists
        /// </summary>
        public string CommercialId { get; set; }

    }
}
