namespace COMPANY.Application.Models
{
    /// <summary>
    /// a class describe country model
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// Id of the country
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the code of the country
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// the name in English of country
        /// </summary>
        public string NomEnGb { get; set; }

        /// <summary>
        /// the name in French of country
        /// </summary>
        public string NomFrFr { get; set; }
    }

    /// <summary>
    /// a class describe department model
    /// </summary>
    public class DepartementModel
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Code of the department
        /// </summary>
        public string DepartementCode { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public string DepartementNom { get; set; }

        /// <summary>
        /// The id of the country associate with this department
        /// </summary>
        public string CountryId { get; set; }
    }
}
