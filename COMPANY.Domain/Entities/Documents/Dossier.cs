namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// a class describe dossier entity
    /// </summary>
    public partial class Dossier : Entity<string>, IRecordable, IReferencable, IFollowAgence
    {
        #region informations

        /// <summary>
        /// dossier Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the date de Pose with this dossier
        /// </summary>
        public DateTime? DatePose { get; set; }

        /// <summary>
        /// the date de Création with this dossier
        /// </summary>
        public DateTime? DateCreation { get; set; }

        /// <summary>
        /// the date d éxpiration with this dossier
        /// </summary>
        public DateTime? DateExpiration { get; set; }

        /// <summary>
        /// the contact of the client.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// the address of client.
        /// </summary>
        public Address SiteIntervention { get; set; }

        /// <summary>
        /// the first phone number of the client
        /// </summary>
        public string FirstPhoneNumber { get; set; }

        /// <summary>
        /// the second phone number of the client
        /// </summary>
        public string SecondPhoneNumber { get; set; }

        /// <summary>
        /// the status of dossier
        /// </summary>
        public DossierStatus Status { get; set; }

        /// <summary>
        /// the raison annulation of bon dossier
        /// </summary>
        public string RaisonAnnulation { get; set; }

        #endregion

        #region others

        /// <summary>
        /// the technical viste of dossier
        /// </summary>
        public VisteTechnique VisteTechnique { get; set; }

        /// <summary>
        /// the note of dossier
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// the history of dossier
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// represent the memos that this dossier owns.
        /// </summary>
        public ICollection<MemoDossier> Memos { get; set; }

        #endregion

        #region information installation

        /// <summary>
        /// the type Chauffage of dossier
        /// </summary>
        public TypeChauffage TypeChauffage { get; set; }

        /// <summary>
        /// the id of type Chauffage of dossier
        /// </summary>
        public string TypeChauffageId { get; set; }

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

        /// <summary>
        /// the additional information of site installation
        /// </summary>
        public Dictionary<string, string> SiteInstallationInformationsSupplementaire { get; set; }

        #endregion

        #region information first RDV

        /// <summary>
        /// the commercial id associate with this dossier
        /// </summary>
        public string CommercialId { get; set; }

        /// <summary>
        /// the commercial associate with this dossier
        /// </summary>
        public User Commercial { get; set; }

        /// <summary>
        /// the date of first RDV of this dossier
        /// </summary>
        public DateTime? DateRDV { get; set; }

        #endregion

        #region antsroute

        /// <summary>
        /// the id antsroute associte with this dossier
        /// </summary>
        public string AntsrouteOrderId { get; set; }

        #endregion

        #region relationships

        /// <summary>
        /// the id of type logement of dossier
        /// </summary>
        public string LogementTypeId { get; set; }

        /// <summary>
        /// the type logement of dossier
        /// </summary>
        public LogementType LogementType { get; set; }

        /// <summary>
        /// the id of source lead of dossier
        /// </summary>
        public string SourceLeadId { get; set; }

        /// <summary>
        /// the source lead of dossier
        /// </summary>
        public SourceDuLead SourceLead { get; set; }

        /// <summary>
        /// the client of type <see cref="ClientType.Obliges"/>
        /// </summary>
        public Client PrimeCEE { get; set; }

        /// <summary>
        /// the id client of type <see cref="ClientType.Obliges"/>
        /// </summary>
        public string PrimeCEEId { get; set; }

        /// <summary>
        /// the client of this folder
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// the id of the client of this folder
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the agence id associate with this dossier
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence associate with this dossier
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// the echange commercial associate with this dossier
        /// </summary>
        public EchangeCommercial PremierRdv { get; set; }

        /// <summary>
        /// the echange commercial id associate with this dossier
        /// </summary>
        public string PremierRdvId { get; set; }

        /// <summary>
        /// the list of commercial exchange associate with this entity
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercials { get; set; }

        /// <summary>
        /// the list of Dossier Installations of dossier
        /// </summary>
        public ICollection<DossierInstallation> DossierInstallations { get; set; }

        /// <summary>
        /// the list of devis associate with this entity
        /// </summary>
        public ICollection<Devis> Devis { get; set; }

        /// <summary>
        /// the list of PVs associate with this dossier
        /// </summary>
        public ICollection<DossierPV> PVs { get; set; }

        /// <summary>
        /// the list of sms associate with this dossier
        /// </summary>
        public ICollection<Sms> Sms { get; set; }

        /// <summary>
        /// list of bons bons commande associate with this entity
        /// </summary>
        public ICollection<BonCommande> BonsCommandes { get; set; }

        #endregion
    }

    public partial class Dossier
    {
        public Dossier()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Dossier");

            EchangeCommercials = new HashSet<EchangeCommercial>();
            DossierInstallations = new HashSet<DossierInstallation>();
            BonsCommandes = new HashSet<BonCommande>();
            Devis = new HashSet<Devis>();
            PVs = new HashSet<DossierPV>();
            Sms = new HashSet<Sms>();
            Historique = new HashSet<ChangesHistory>();
            Memos = new HashSet<MemoDossier>();
        }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Reference}";
    }
}
