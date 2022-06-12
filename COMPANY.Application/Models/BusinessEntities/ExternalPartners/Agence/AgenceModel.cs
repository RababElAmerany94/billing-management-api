namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class that defines a model for <see cref="Domain.Entities.Agence"/>
    /// </summary>
    public class AgenceModel : EntityModel<string>
    {
        /// <summary>
        /// the reference of agence
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the name of the company
        /// </summary>
        public string RaisonSociale { get; set; }

        /// <summary>
        /// the forme juridique of agence
        /// </summary>
        public string FormeJuridique { get; set; }

        /// <summary>
        /// the capital of agence
        /// </summary>
        public string Capital { get; set; }

        /// <summary>
        /// the numero TVA INTRA of agence
        /// </summary>
        public string NumeroTvaINTRA { get; set; }

        /// <summary>
        /// Directory Identification System institutions
        /// </summary>
        public string Siret { get; set; }

        /// <summary>
        /// the email of the agence
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// phone number of the agence
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the accounting code of agence
        /// </summary>
        public string CodeComptable { get; set; }

        /// <summary>
        /// the date of start activities of agence
        /// </summary>
        public DateTime? DateDebutActivite { get; set; }

        /// <summary>
        /// the date of end activities of agence
        /// </summary>
        public DateTime? DateFinActivite { get; set; }

        /// <summary>
        /// is this Agence accessible to connect 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// the address facture of the agence
        /// </summary>
        /// <remarks>
        public ICollection<Address> AdressesFacturation { get; set; }

        /// <summary>
        /// the address livraison of the agence
        /// </summary>
        /// <remarks>
        public ICollection<Address> AdressesLivraison { get; set; }

        /// <summary>
        /// represent the contacts that this agence owns.
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// represent the memos that this agence owns.
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        ///the list of changes that occurred on this entity instance
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// the id of regulration mode id associate with this agence
        /// </summary>
        public string RegulationModeId { get; set; }

        /// <summary>
        /// the login of the agence, navigation property
        /// </summary>
        public UserModel AgenceLogin { get; set; }
    }
}
