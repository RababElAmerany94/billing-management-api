namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Authentification;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// the roles for users, a user can have multiple roles, and a role can be assigned to many users
    /// </summary>
    public partial class Role : Entity<int>
    {
        /// <summary>
        /// the Name of the role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the users associated with this role
        /// </summary>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// the permission of this role
        /// </summary>
        public ICollection<Permission> Permissions { get; set; }

        /// <summary>
        /// the modules they have this role
        /// </summary>
        public ICollection<RoleModule> Modules { get; set; }

        /// <summary>
        /// build the search term for querying
        /// </summary>
        public override void BuildSearchTerms()
            => SearchTerms = $"{Name}";
    }

    /// <summary>
    /// a partial class for the role class
    /// </summary>
    public partial class Role
    {
        /// <summary>
        /// Admin Role Name
        /// </summary>
        public const string Admin = "admin";

        /// <summary>
        /// Controleur Role Name
        /// </summary>
        public const string Controleur = "controleur";

        /// <summary>
        /// Directeur Role Name
        /// </summary>
        public const string Directeur = "directeur";

        /// <summary>
        /// Technicien Role Name
        /// </summary>
        public const string Technicien = "technicien";

        /// <summary>
        /// Commercial Role Name
        /// </summary>
        public const string Commercial = "commercial";

        /// <summary>
        /// Agence Role Name
        /// </summary>
        public const string AdminAgence = "admin agence";

        /// <summary>
        /// create an instant of role with admin Name
        /// </summary>
        /// <returns></returns>
        public static Role CreateAdminRole()
            => new Role() { Id = (int)UserRole.Admin, Name = Admin, CreatedOn = new DateTime(2020, 01, 01), LastModifiedOn = new DateTime(2020, 01, 01), SearchTerms = $"admin" };

        /// <summary>
        /// create an instant of role with Controleur Name
        /// </summary>
        /// <returns></returns>
        public static Role CreateControleurRole()
            => new Role() { Id = (int)UserRole.Controleur, Name = Controleur, CreatedOn = new DateTime(2020, 01, 01), LastModifiedOn = new DateTime(2020, 01, 01), SearchTerms = $"controleur" };

        /// <summary>
        /// create an instant of role with Directeur Commercial Name
        /// </summary>
        /// <returns></returns>
        public static Role CreateDirecteurRole()
            => new Role() { Id = (int)UserRole.Directeur, Name = Directeur, CreatedOn = new DateTime(2020, 01, 01), LastModifiedOn = new DateTime(2020, 01, 01), SearchTerms = $"directeur" };

        /// <summary>
        /// create an instant of role with Technicien Name
        /// </summary>
        /// <returns></returns>
        public static Role CreateTechnicienRole()
            => new Role() { Id = (int)UserRole.Technicien, Name = Technicien, CreatedOn = new DateTime(2020, 01, 01), LastModifiedOn = new DateTime(2020, 01, 01), SearchTerms = $"technicien" };

        /// <summary>
        /// create an instant of role with Commercial Name
        /// </summary>
        /// <returns></returns>
        public static Role CreateCommercialRole()
            => new Role() { Id = (int)UserRole.Commercial, Name = Commercial, CreatedOn = new DateTime(2020, 01, 01), LastModifiedOn = new DateTime(2020, 01, 01), SearchTerms = $"commercial" };

        /// <summary>
        /// create an instant of role with agence Name
        /// </summary>
        /// <returns></returns>
        public static Role CreateAgenceAdmin()
            => new Role() { Id = (int)UserRole.AdminAgence, Name = AdminAgence, CreatedOn = new DateTime(2020, 01, 01), LastModifiedOn = new DateTime(2020, 01, 01), SearchTerms = $"agence admin" };

    }
}
