namespace COMPANY.Application.Models
{
    /// <summary>
    /// this class is used to describe the login creation requirement for an agence
    /// </summary>
    public class CreateLoginModel
    {
        /// <summary>
        /// the id of the Account you are creating the login for it 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the user name to be used
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// is active or not
        /// </summary>
        public bool IsActive { get; set; }
    }
}
