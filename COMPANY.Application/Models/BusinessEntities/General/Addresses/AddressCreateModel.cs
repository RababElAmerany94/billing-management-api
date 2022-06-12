namespace COMPANY.Application.Models.BusinessEntitiesModels.AddressModel
{
    /// <summary>
    /// a class that defines create address model
    /// </summary>
    public class AddressCreateModel
    {
        /// <summary>
        /// the address
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// the complement address
        /// </summary>
        public string ComplementAdresse { get; set; }

        /// <summary>
        /// the city
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// the code postal
        /// </summary>
        public string CodePostal { get; set; }

        /// <summary>
        /// the department
        /// </summary>
        public string Departement { get; set; }

        /// <summary>
        /// the country
        /// </summary>
        public string Pays { get; set; }

        /// <summary>
        /// is default address
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// is this address to add 
        /// </summary>
        public bool? IsNew { get; set; }
    }
}
