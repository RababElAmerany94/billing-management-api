namespace COMPANY.Application.Models
{
    /// <summary>
    /// a model that defines the login of a user
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// the user name of the user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// the password of the user
        /// </summary>
        public string Password { get; set; }
    }
}
