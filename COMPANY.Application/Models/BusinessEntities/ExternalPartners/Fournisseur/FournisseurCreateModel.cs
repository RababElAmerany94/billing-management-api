namespace COMPANY.Application.Models
{
    using COMPANY.Domain.Entities;
    using System.Collections.Generic;

    public class FournisseurCreateModel
    {
        /// <summary>
        /// the reference of fournisseur
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the name of the company
        /// </summary>
        public string RaisonSociale { get; set; }

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
    }
}
