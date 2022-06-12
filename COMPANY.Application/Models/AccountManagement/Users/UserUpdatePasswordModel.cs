namespace COMPANY.Application.Models
{
    /// <summary>
    /// a model that describe the Updating password Requirements
    /// </summary>
    public class UserUpdatePasswordModel
    {
        /// <summary>
        /// the id of the user we want to update the id for it
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the new password
        /// </summary>
        public string NewPassword { get; set; }
    }

}