namespace COMPANY.Application.Models.BusinessEntitiesModels.AccountModels
{
    /// <summary>
    /// a class describe minimum information about user
    /// </summary>
    public class UserLiteModel
    {
        /// <summary>
        /// a unique Registration number that identify the user
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// the id of the user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the user name of user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// the full name of user
        /// </summary>
        public string FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// the id of the role of this user
        /// </summary>
        public int RoleId { get; set; }
    }
}
