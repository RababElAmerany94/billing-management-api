namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.EchangeCommercial;
    using COMPANY.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// an entity describe commercial exchange
    /// </summary>
    public class EchangeCommercial : Entity<string>, IMemoable, IRecordable, IFollowAgence
    {
        public EchangeCommercial()
        {
            Id = Common.Helpers.IdentityDocument.Generate("EchangeCommercial");

            PremiersRdvsDossiers = new List<Dossier>();
            Addresses = new HashSet<Address>();
            Contacts = new HashSet<Contact>();
            Historique = new HashSet<ChangesHistory>();
            Memos = new HashSet<Memo>();
        }

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
        /// phone number of the commercial 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the status of commercial exchange
        /// </summary>
        public EchangeCommercialStatus Status { get; set; }

        /// <summary>
        /// list of contacts of the commercial exchange
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// the addresses of the commercial exchange
        public ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// represent the memos that this commercial exchange owns. 
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        /// the commercial exchange changes history
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        #region relations

        /// <summary>
        /// the task type id of this commercial exchange
        /// </summary>
        public string TacheTypeId { get; set; }

        /// <summary>
        /// the task type of this commercial exchange
        /// </summary>
        public AgendaEvenement TacheType { get; set; }

        /// <summary>
        /// the appel type id of this commercial exchange
        /// </summary>
        public string TypeAppelId { get; set; }

        /// <summary>
        /// the appel type of this commercial exchange
        /// </summary>
        public AgendaEvenement TypeAppel { get; set; }

        /// <summary>
        /// the appointment type id of this commercial exchange
        /// </summary>
        public string RdvTypeId { get; set; }

        /// <summary>
        /// the appointment type of this commercial exchange
        /// </summary>
        public AgendaEvenement RdvType { get; set; }

        /// <summary>
        /// the category id of this commercial exchange
        /// </summary>
        public string CategorieId { get; set; }

        /// <summary>
        /// the category of this commercial exchange
        /// </summary>
        public AgendaEvenement Categorie { get; set; }

        /// <summary>
        /// the source RDV type id of this commercial exchange
        /// </summary>
        public string SourceRDVId { get; set; }

        /// <summary>
        /// the source RDV type of this commercial exchange
        /// </summary>
        public AgendaEvenement SourceRDV { get; set; }

        /// <summary>
        /// the responsible with this commercial exchange
        /// </summary>
        public User Responsable { get; set; }

        /// <summary>
        /// the id of the responsible with this commercial exchange
        /// </summary>
        public string ResponsableId { get; set; }

        /// <summary>
        /// the client of this commercial exchange
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// the id of the client of this commercial exchange
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the dossier of this tache
        /// </summary>
        public Dossier Dossier { get; set; }

        /// <summary>
        /// the dossier of this tache
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the agence id of this commercial exchange
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence of this commercial exchange
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// the createur id of this commercial exchange
        /// </summary>
        public string CreateurId { get; set; }

        /// <summary>
        /// the createur of this commercial exchange
        /// </summary>
        public User Createur { get; set; }

        /// <summary>
        /// the list Google calendar event of this commercial exchange
        /// </summary>
        public ICollection<GoogleCalendarEchangeCommercial> GoogleCalendarEvents { get; set; }

        /// <summary>
        /// the list of first RDV event of this commercial exchange
        /// </summary>
        public ICollection<Dossier> PremiersRdvsDossiers { get; set; }

        #endregion

        /// <summary>
        /// build the search term query
        /// </summary>
        public override void BuildSearchTerms()
            => SearchTerms = $"{Titre}";
    }
}
