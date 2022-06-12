namespace COMPANY.Application.Models
{
    using System;
    
    /// <summary>
    /// a class that describe the User Creation Requirement
    /// </summary>
    public class UserCreateModel
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
        /// the user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// is the user active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// a unique Registration number that identify the user
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// the id of the agence related to this user
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the id of the role of this user
        /// </summary>
        public int RoleId { get; set; }
    }
}
