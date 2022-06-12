namespace COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial
{
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.EchangeCommercial;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// the class describe commercial exchange create model
    /// </summary>
    public class EchangeCommercialCreateModel
    {
        /// <summary>
        /// title of commercial exchange
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// description of commercial exchange
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the date of commercial exchange
        /// </summary>
        public DateTime DateEvent { get; set; }

        /// <summary>
        /// the time of action of commercial exchange
        /// </summary>
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// the duree of commercial exchange
        /// </summary>
        public TimeSpan? Duree { get; set; }

        /// <summary>
        /// the type of commercial exchange
        /// </summary>
        public EchangeCommercialType Type { get; set; }

        /// <summary>
        /// the priority of commercial exchange
        /// </summary>
        public EchangeCommercialPriority? Priorite { get; set; }

        /// <summary>
        /// the status of commercial exchange
        /// </summary>
        public EchangeCommercialStatus Status { get; set; }

        /// <summary>
        /// phone number of the commercial 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// list of contacts of the commercial exchange
        /// </summary>
        public ICollection<ContactCreateModel> Contacts { get; set; }

        /// <summary>
        /// the addresses of the commercial exchange
        public ICollection<AddressCreateModel> Addresses { get; set; }

        #region relations

        /// <summary>
        /// the task type id of this commercial exchange
        /// </summary>
        [PropertyName("TacheType")]
        public string TacheTypeId { get; set; }

        /// <summary>
        /// the call type id of this commercial exchange
        /// </summary>
        [PropertyName("TypeAppel")]
        public string TypeAppelId { get; set; }

        /// <summary>
        /// the appointment type id of this commercial exchange
        /// </summary>
        [PropertyName("RdvType")]
        public string RdvTypeId { get; set; }

        /// <summary>
        /// the category id of this commercial exchange
        /// </summary>
        [PropertyName("Categorie")]
        public string CategorieId { get; set; }

        /// <summary>
        /// the source RDV type id of this commercial exchange
        /// </summary>
        [PropertyName("SourceRDV")]
        public string SourceRDVId { get; set; }

        /// <summary>
        /// the id of the responsible with this commercial exchange
        /// </summary>
        [PropertyName("Responsable")]
        public string ResponsableId { get; set; }

        /// <summary>
        /// the id of the client of this commercial exchange
        /// </summary>
        [PropertyName("Client")]
        public string ClientId { get; set; }

        /// <summary>
        /// the dossier of this tache
        /// </summary>
        [PropertyName("Dossier")]
        public string DossierId { get; set; }

        /// <summary>
        /// the agence id of this commercial exchange
        /// </summary>
        [PropertyName("Agence")]
        public string AgenceId { get; set; }

        #endregion
    }
}
