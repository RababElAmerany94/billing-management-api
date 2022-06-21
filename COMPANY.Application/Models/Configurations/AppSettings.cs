using Inova.SpotHit.Models;

namespace COMPANY.Application.Models.GeneralModels
{
    /// <summary>
    /// a class describe information contains appsetting.json
    /// </summary>
    public partial class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public InovaFileManager InovaFileManager { get; set; }
        public TokenAuthentication TokenAuthentication { get; set; }
        public BackgroundService BackgroundService { get; set; }
        public OneSignalSecrets OneSignalSecrets { get; set; }
        public ColumnsNamesPaiementGroupeOblige ColumnsNamesPaiementGroupeOblige { get; set; }
        public GoogleCalendarSecrets GoogleCalendarSecrets { get; set; }
        public AntsrouteSecrets AntsrouteSecrets { get; set; }
        public SpotHitSecrets SpotHitSecrets { get; set; }
    }

    /// <summary>
    /// a class define configuration of connection to database and library in charge of memos
    /// </summary>
    public partial class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string SerilogConnection { get; set; }
    }

    /// <summary>
    /// a class define configuration InovaFileManager
    /// </summary>
    public partial class InovaFileManager
    {
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// the place when we save temporary contract
        /// </summary>
        public string TemporaryFiles { get; set; }
    }

    /// <summary>
    /// a class define configuration of authentication
    /// </summary>
    public partial class TokenAuthentication
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string TokenPath { get; set; }
    }

    /// <summary>
    /// background service configuration
    /// </summary>
    public class BackgroundService
    {
        /// <summary>
        /// launch service in this server
        /// </summary>
        public bool Launch { get; set; }
    }

    /// <summary>
    /// one signal configuration
    /// </summary>
    public class OneSignalSecrets
    {
        public string AppId { get; set; }
        public string APIKey { get; set; }
        public string EndPoint { get; set; }
    }

    /// <summary>
    /// the names of columns paiement groupe oblige
    /// </summary>
    public class ColumnsNamesPaiementGroupeOblige
    {
        public string NumeroAH { get; set; }
        public string Montant { get; set; }
    }

    /// <summary>
    /// configuration of Google calendar
    /// </summary>
    public partial class GoogleCalendarSecrets
    {
        /// <summary>
        /// the email of client we will share with him Calendar
        /// </summary>
        public string ClientEmail { get; set; }

        /// <summary>
        /// Private Key associated with ServiceAccountCredential obtained 
        /// </summary>
        public string PrivateKey { get; set; }
    }

    /// <summary>
    /// secrets of antsroute
    /// </summary>
    public class AntsrouteSecrets
    {
        public string APIKey { get; set; }
        public string CreateBasketOrderEndpoint { get; set; }
        public string GetAndDeleteBasketOrderEndpoint { get; set; }
    }
}
