namespace COMPANY.Application.Models
{
    /// <summary>
    /// a class that define basic login information for a user
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// the id of the login
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the user name of the user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// a flag to determine if the user is active or not
        /// </summary>
        public bool Actif { get; set; }
    }
}
