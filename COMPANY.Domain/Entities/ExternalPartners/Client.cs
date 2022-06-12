namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.ExternalPartners;
    using COMPANY.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class that defines a client
    /// </summary>
    public class Client : Entity<string>, IRecordable, IMemoable, IFollowAgence, IReferencable
    {
        public Client()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Client");

            Memos = new HashSet<Memo>();
            Historique = new HashSet<ChangesHistory>();
            Addresses = new HashSet<Address>();
            Contacts = new HashSet<Contact>();
        }

        #region information client

        /// <summary>
        /// client Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// client origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// the first name of the client
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// last Name of the Client
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the phone number of the client
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the client Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the client website
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// Directory Identification System institutions
        /// </summary>
        public string Siret { get; set; }

        /// <summary>
        /// the accounting code for the client
        /// </summary>
        public string CodeComptable { get; set; }

        /// <summary>
        /// type of the client
        /// </summary>
        public ClientType Type { get; set; }

        /// <summary>
        /// the genre of the client
        /// </summary>
        public ClientGenre Genre { get; set; }

        /// <summary>
        /// is client a Sous Traitant
        /// </summary>
        public bool IsSousTraitant { get; set; }

        /// <summary>
        /// the addresses of the client
        /// </summary>
        public ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// list of contacts of the client. 
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }

        #endregion

        #region information installation

        /// <summary>
        /// the dateReceptionLead with this client
        /// </summary>
        public DateTime? DateReceptionLead { get; set; }

        /// <summary>
        /// the parcelle cadastrale of client
        /// </summary>
        public string ParcelleCadastrale { get; set; }

        /// <summary>
        /// the surface traiter of client
        /// </summary>
        public double? SurfaceTraiter { get; set; }

        /// <summary>
        /// the nombre personne
        /// </summary>
        public string NombrePersonne { get; set; }

        /// <summary>
        /// the is maison de plus de 2ans of client
        /// </summary>
        public bool? IsMaisonDePlusDeDeuxAns { get; set; }

        /// <summary>
        /// the precarite of client
        /// </summary>
        public PrecariteType? Precarite { get; set; }

        /// <summary>
        /// the revenue fiscale reference of client
        /// </summary>
        public string RevenueFiscaleReference { get; set; }

        /// <summary>
        /// the numero AH of client
        /// </summary>
        public string NumeroAH { get; set; }

        /// <summary>
        /// the type travaux of client
        /// </summary>
        public TypeTravaux? TypeTravaux { get; set; }

        #endregion

        #region information devis

        /// <summary>
        /// the label prime CEE of client
        /// </summary>
        public string LabelPrimeCEE { get; set; }

        /// <summary>
        /// the note devis for client type <see cref="ClientType.Obliges">
        /// </summary>
        public string NoteDevis { get; set; }

        #endregion

        #region relationships

        /// <summary>
        /// the id of source lead of dossier
        /// </summary>
        public string SourceLeadId { get; set; }

        /// <summary>
        /// the source lead of dossier
        /// </summary>
        public SourceDuLead SourceLead { get; set; }

        /// <summary>
        /// the type Chauffage of client
        /// </summary>
        public TypeChauffage TypeChauffage { get; set; }

        /// <summary>
        /// the id of type Chauffage of dossier
        /// </summary>
        public string TypeChauffageId { get; set; }

        /// <summary>
        /// the id of type logement of client
        /// </summary>
        public string LogementTypeId { get; set; }

        /// <summary>
        /// the type logement of client
        /// </summary>
        public LogementType LogementType { get; set; }

        /// <summary>
        /// the client of type <see cref="ClientType.Obliges"/>
        /// </summary>
        public Client PrimeCEE { get; set; }

        /// <summary>
        /// the id client of type <see cref="ClientType.Obliges"/>
        /// </summary>
        public string PrimeCEEId { get; set; }

        /// <summary>
        /// the regulation mode id of client
        /// </summary>
        public string RegulationModeId { get; set; }

        /// <summary>
        /// the regulation mode of client
        /// </summary>
        public RegulationMode RegulationMode { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence related to this client, could be null
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// list of client associate with this client type <see cref="ClientType.Obliges"/>
        /// </summary>
        public ICollection<Client> Clients { get; set; }

        /// <summary>
        /// list of dossier associate with this client type <see cref="ClientType.Obliges"/>
        /// </summary>
        public ICollection<Dossier> Dossiers { get; set; }

        /// <summary>
        /// list of devis associate with this client
        /// </summary>
        public ICollection<Devis> Devis { get; set; }

        /// <summary>
        /// the list of avoirs associate with this client
        /// </summary>
        public ICollection<Avoir> Avoirs { get; set; }

        /// <summary>
        /// the list of factures associate with this client
        /// </summary>
        public ICollection<Facture> Factures { get; set; }

        /// <summary>
        /// the list of commercial exchange associate with this client
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercials { get; set; }

        /// <summary>
        /// the list of sms associate with this client
        /// </summary>
        public ICollection<Sms> Sms { get; set; }

        /// <summary>
        /// the relationship of client
        /// </summary>
        public ICollection<ClientRelation> Relations { get; set; }

        /// <summary>
        /// list of bons bons commande associate with this entity
        /// </summary>
        public ICollection<BonCommande> BonsCommandes { get; set; }

        /// <summary>
        /// the list of commercial associate with this client
        /// </summary>
        public ICollection<ClientCommercial> Commercials { get; set; }

        #endregion

        #region others

        /// <summary>
        /// the client changes history
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// represent the memos that this client owns.
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        #endregion

        /// <summary>
        /// build the search terms for this entity, to be used in querying data
        /// </summary>
        public override void BuildSearchTerms() 
            => SearchTerms = $"{FirstName} {LastName} {Reference}";
    }
}
