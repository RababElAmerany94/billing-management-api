namespace COMPANY.Domain.Enums.Authentification
{
    /// <summary>
    /// this enumeration defines the permissions of application
    /// ranges of each module :
    /// General : >= 1
    /// Client : >= 20
    /// </summary>
    public enum Access : int
    {
        #region general

        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4,
        ManipulationLogin = 5

        #endregion

    }
}
