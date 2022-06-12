namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntities.Relations.ClientCommercial;
    using COMPANY.Application.Models.BusinessEntities.Relations.ClientRelation;
    using COMPANY.Application.Models.BusinessEntitiesModels.ClientModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.ExternalPartners;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class that defines a Model for <see cref="Domain.Entities.Client"/>
    /// </summary>
    public class ClientModel : EntityModel<string>
    {
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
        /// the full name of the Client
        /// </summary>
        public string FullName { get => $"{FirstName} {LastName}"; }

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
        /// the id of source lead of dossier
        /// </summary>
        public string SourceLeadId { get; set; }

        /// <summary>
        /// the source lead of dossier
        /// </summary>
        public SourceDuLead SourceLead { get; set; }

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
        /// the type Chauffage of dossier
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
        public ClientListModel PrimeCEE { get; set; }

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
        public RegulationModeModel RegulationMode { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence related to this client, could be null
        /// </summary>
        public AgenceModel Agence { get; set; }

        /// <summary>
        /// the relationship of client
        /// </summary>
        public ICollection<ClientRelationModel> Relations { get; set; }

        #endregion

        /// <summary>
        /// the client changes history
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// represent the memos that this client owns.
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        /// the list of commercial associate with this client
        /// </summary>
        public ICollection<ClientCommercialModel> Commercials { get; set; }
    }
}
