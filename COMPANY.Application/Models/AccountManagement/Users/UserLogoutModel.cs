namespace COMPANY.Application.Models
{
    /// <summary>
    /// a class that describe a logout operation requirement
    /// </summary>
    public class UserLogoutModel
    {
        /// <summary>
        /// the token of the user trying to log out
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// the id of the user is trying to logout
        /// </summary>
        public int UserId { get; set; }
    }
}
