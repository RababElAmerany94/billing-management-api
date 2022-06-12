using COMPANY.Application.Models.BusinessEntities.General.Base;
using COMPANY.Domain.Entities;
using COMPANY.Domain.Entities.OwnedEntities;
using System.Collections.Generic;

namespace COMPANY.Application.Models
{
    /// <summary>
    /// the <see cref="Domain.Entities.Fournisseur"/> Model
    /// </summary>
    public class FournisseurModel : EntityModel<string>
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
        public AgenceModel Agence { get; set; }

    }
}
