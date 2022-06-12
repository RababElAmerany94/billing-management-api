namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class that defines an address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// the adresse
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// the complement adresse
        /// </summary>
        public string ComplementAdresse { get; set; }
        
        /// <summary>
        /// the ville of adresse
        /// </summary>
        public string Ville { get; set; }
        
        /// <summary>
        /// the code postal of adresse
        /// </summary>
        public string CodePostal { get; set; }
        
        /// <summary>
        /// the departement of adresse
        /// </summary>
        public string Departement { get; set; }
        
        /// <summary>
        /// the pays of adresse
        /// </summary>
        public string Pays { get; set; }
        
        /// <summary>
        /// is default adresse
        /// </summary>
        public bool? IsDefault { get; set; }
    }

}
