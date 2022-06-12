namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class that describe an agence
    /// </summary>
    public class Agence : Entity<string>, IRecordable, IMemoable
    {
        public Agence()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Agence");

            AdressesFacturation = new HashSet<Address>();
            AdressesLivraison = new HashSet<Address>();
            Contacts = new HashSet<Contact>();
            Memos = new HashSet<Memo>();
        }

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
        public ICollection<Address> AdressesFacturation { get; set; }

        /// <summary>
        /// the address livraison of the agence
        /// </summary>
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

        #region relationship

        /// <summary>
        /// the id of regulration mode id associate with this agence
        /// </summary>
        public string RegulationModeId { get; set; }

        /// <summary>
        /// the regulration mode id associate with this agence
        /// </summary>
        public RegulationMode RegulationMode { get; set; }

        /// <summary>
        /// the login of this agence
        /// </summary>
        public string AgenceLoginId { get; set; }

        /// <summary>
        /// the login of the agence, navigation property
        /// </summary>
        public User AgenceLogin { get; set; }

        /// <summary>
        /// list of user he has this agence
        /// </summary>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// the list of produit associate with agence 
        /// </summary>
        public ICollection<Produit> Produits { get; set; }

        /// <summary>
        /// the list price of produit of this agence
        /// </summary>
        public ICollection<PrixProduitParAgence> PrixProduitParAgences { get; set; }

        /// <summary>
        /// list of devis associate with this entity
        /// </summary>
        public ICollection<Devis> Devis { get; set; }

        /// <summary>
        /// the list of dossiers associate with this entity
        /// </summary>
        public ICollection<Dossier> Dossiers { get; set; }

        /// <summary>
        /// the list of avoirs associate with this entity
        /// </summary>
        public ICollection<Avoir> Avoirs { get; set; }

        /// <summary>
        /// the list of facture associate with this entity
        /// </summary>
        public ICollection<Facture> Factures { get; set; }

        /// <summary>
        /// the list of paiements associate with this entity
        /// </summary>
        public ICollection<Paiement> Paiements { get; set; }

        /// <summary>
        /// the list of commercial exchange associate with this entity
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercials { get; set; }

        /// <summary>
        /// list of bons bons commande associate with this entity
        /// </summary>
        public ICollection<BonCommande> BonsCommandes { get; set; }

        #endregion

        /// <summary>
        /// build the search term for querying
        /// </summary>
        public override void BuildSearchTerms()
            => SearchTerms = $"{Reference} {RaisonSociale} {Siret}".ToLower();
    }
}
