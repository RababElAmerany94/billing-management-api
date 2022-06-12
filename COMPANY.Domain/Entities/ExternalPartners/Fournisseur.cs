namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// a class that represent a Supplier 
    /// </summary>
    public class Fournisseur : Entity<string>, IRecordable, IReferencable, IFollowAgence
    {
        public Fournisseur()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Fournisseur");

            Historique = new HashSet<ChangesHistory>();
            Addresses = new HashSet<Address>();
            Contacts = new HashSet<Contact>();
        }

        /// <summary>
        /// the reference of fournisseur
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the name of the company
        /// </summary>
        public string RaisonSociale { get; set; }

        /// <summary>
        /// the fournisseur changes history
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// the web site of fournisseur
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// the code comptable of the fournisseur
        /// </summary>
        public string CodeComptable { get; set; }

        /// <summary>
        /// the siret of the fournisseur
        /// </summary>
        public string Siret { get; set; }

        /// <summary>
        /// the phone number of the fournisseur
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the client Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the addresses of the fournisseur
        /// </summary>
        /// <remarks>
        public ICollection<Address> Addresses { get; set; }

        /// <summary> 
        /// the contact information of the fournisseur
        /// </summary>
        /// <remarks>
        public ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence related to this supplier, could be null
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// the list of produit associae with this fournisseur
        /// </summary>
        public virtual ICollection<Produit> Produits { get; set; }

        /// <summary>
        /// build the search term query
        /// </summary>
        public override void BuildSearchTerms() => SearchTerms = $"{Reference} {RaisonSociale}".ToLower();
    }

}
