namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class that describe a user
    /// </summary>
    public class User : Entity<string>, IRecordable, IMemoable
    {

        public User()
        {
            Id = Common.Helpers.IdentityDocument.Generate("User");

            Historique = new HashSet<ChangesHistory>();
            Memos = new HashSet<Memo>();
        }

        /// <summary>
        /// the first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// phone number of the user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// the user Name of this user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// the user hashed password
        /// </summary>
        public string Passwordhash { get; set; }

        /// <summary>
        /// is the user active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// last time the user was logged in
        /// </summary>
        public DateTime? LastConnection { get; set; }

        /// <summary>
        /// the count of how many login fails this user have  
        /// </summary>
        public int AccessfailedCount { get; set; }

        /// <summary>
        /// a unique Registration number that identify the user
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// modificaton history
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// list memos of this user
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        /// the calendar identification
        /// </summary>
        public string GoogleCalendarId { get; set; }

        #region relationships

        /// <summary>
        /// the Agence how owns this login, navigation prop
        /// </summary>
        public Agence AgenceLogin { get; set; }

        /// <summary>
        /// the id of the Agence related to this user
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the Agence related to this user, could be null
        /// </summary>
        public Agence Agence { get; set; }

        /// <summary>
        /// the id of the role of this user
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// the role of the user
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// the list of devis associate with this entity
        /// </summary>
        public ICollection<Devis> Devis { get; set; }

        /// <summary>
        /// the list of dossiers associate with this entity
        /// </summary>
        public ICollection<Dossier> Dossiers { get; set; }

        /// <summary>
        /// the list of fiche controles associate with this entity
        /// </summary>
        public ICollection<FicheControle> FicheControles { get; set; }

        /// <summary>
        /// the list of commercial exchange associate with this entity
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercials { get; set; }

        /// <summary>
        /// the list of commercial exchange associate with this entity
        /// </summary>
        public ICollection<EchangeCommercial> EchangeCommercialsCreateurs { get; set; }

        /// <summary>
        /// the list Google calendar event of this user
        /// </summary>
        public ICollection<GoogleCalendarEchangeCommercial> GoogleCalendarEvents { get; set; }

        /// <summary>
        /// the list of notification of this user
        /// </summary>
        public ICollection<Notification> Notifications { get; set; }

        /// <summary>
        /// list of bons bons commande associate with this entity
        /// </summary>
        public ICollection<BonCommande> BonsCommandes { get; set; }

        /// <summary>
        /// list of client commercial associate with this entity
        /// </summary>
        public ICollection<ClientCommercial> ClientCommercials { get; set; }

        /// <summary>
        /// list of dossier installation associate with this entity
        /// </summary>
        public IEnumerable<DossierInstallation> DossierInstallations { get; set; }

        #endregion

        /// <summary>
        /// build the search string for querying users
        /// </summary>
        public override void BuildSearchTerms()
            => SearchTerms = $"{FirstName} {LastName} {RegistrationNumber}";
    }
}
