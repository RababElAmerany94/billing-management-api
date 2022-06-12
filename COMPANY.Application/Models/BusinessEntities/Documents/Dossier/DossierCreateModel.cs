namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe <see cref="Domain.Entities.Dossier"/> create model
    /// </summary>
    public class DossierCreateModel
    {
        #region informations

        /// <summary>
        /// dossier Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the Date de Pose with this dossier
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
        public ContactCreateModel Contact { get; set; }

        /// <summary>
        /// the address of client.
        /// </summary>
        public AddressCreateModel SiteIntervention { get; set; }

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
        /// the additional information of site installation
        /// </summary>
        public Dictionary<string, string> SiteInstallationInformationsSupplementaire { get; set; }

        #endregion

        #region others

        /// <summary>
        /// the note of dossier
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// the raison annulation of bon dossier
        /// </summary>
        public string RaisonAnnulation { get; set; }

        #endregion

        #region information installation

        /// <summary>
        /// the id of type Chauffage of dossier
        /// </summary>
        public string TypeChauffageId { get; set; }

        /// <summary>
        /// the id of source lead of dossier
        /// </summary>
        public string SourceLeadId { get; set; }

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

        #region information first RDV

        /// <summary>
        /// the commercial id associate with this dossier
        /// </summary>
        public string CommercialId { get; set; }

        /// <summary>
        /// the date of first RDV of this dossier
        /// </summary>
        public DateTime? DateRDV { get; set; }

        /// <summary>
        /// the echange commercial id associate with this dossier
        /// </summary>
        public string PremierRdvId { get; set; }

        #endregion

        #region relationships

        /// <summary>
        /// the id of type logement of dossier
        /// </summary>
        public string LogementTypeId { get; set; }

        /// <summary>
        /// the id client of type <see cref="ClientType.Obliges"/>
        /// </summary>
        public string PrimeCEEId { get; set; }

        /// <summary>
        /// the id of the client of this folder
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the agence id associate with this dossier
        /// </summary>
        public string AgenceId { get; set; }

        #endregion
    }
}
