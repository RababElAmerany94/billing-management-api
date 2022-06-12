namespace COMPANY.Application.Models
{
    /// <summary>
    /// a class that defines a model that holds the token
    /// </summary>
    public class UserTokenModel
    {
        /// <summary>
        /// the generated token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// the id of the role of the user
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// is the user active or not
        /// </summary>
        public bool Actif { get; set; }
    }
}
