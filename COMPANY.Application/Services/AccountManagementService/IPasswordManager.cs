namespace COMPANY.Application.Services.AuthService
{
    public interface IPasswordManager
    {
        /// <summary>
        /// Creates a signature for a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>the "salt:hash" for the password.</returns>
        string CreatePasswordSalt(string password);

        /// <summary>
        /// Validate if a password will generate the passed in salt:hash.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <param name="saltHash">The "salt:hash" this password should generate.</param>
        /// <returns>true if we have a match.</returns>
        bool IsPasswordValid(string password, string saltHash);
    }
}
