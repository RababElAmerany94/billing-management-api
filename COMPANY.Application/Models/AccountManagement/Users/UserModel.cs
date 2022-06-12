namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.AccountManagement.Role;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Common.Constants;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    /// <summary>
    /// a class that describe a <see cref="User"/> Model
    /// </summary>
    public class UserModel : EntityModel<string>
    {
        /// <summary>
        /// the first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the full name of user
        /// </summary>
        public string FullName { get => $"{FirstName} {LastName}"; }

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
        /// the Agence how owns this login, navigation prop
        /// </summary>
        public AgenceModel AgenceLogin { get; set; }

        /// <summary>
        /// the id of the Agence related to this user
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the Agence related to this user, could be null
        /// </summary>
        public AgenceModel Agence { get; set; }

        /// <summary>
        /// the id of the role of this user
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// the role of the user
        /// </summary>
        public RoleModel Role { get; set; }

        /// <summary>
        /// the creation time of the account
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// modificaton history
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// list memos of this user
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        /// this method generate a Claim principle for the user base on the values he owns
        /// </summary>
        /// <returns>an instant of the claim principle</returns>
        public ClaimsPrincipal GenerateClaimsPrincipal()
        {
            var modules = Role.Modules
                .Select(e => e.ModuleId)
                .Distinct()
                .ToList();

            var permissions = Role
                .Permissions
                .ToList();

            // generate the claims associated with the user
            var claims = new List<Claim>()
            {
                new Claim(ClaimsTypes.UserId, Id),
                new Claim(ClaimsTypes.AgenceId, AgenceId ?? ""),
                new Claim(ClaimsTypes.RoleId, RoleId.ToString()),
                new Claim(ClaimsTypes.IsActive, IsActive.ToString()),
                new Claim(ClaimsTypes.Name, $"{LastName} {FirstName}"),
                new Claim(ClaimsTypes.Modules, modules.ToJson()),
                new Claim(ClaimsTypes.Permissions, permissions.ToJson()),
                new Claim(ClaimsTypes.Username, UserName),
                new Claim(ClaimsTypes.Email, Email ?? ""),
                new Claim(ClaimsTypes.Role, Role.Name),
            };

            // return the generated Claim Principle
            return new ClaimsPrincipal(new ClaimsIdentity(claims));
        }
    }
}
