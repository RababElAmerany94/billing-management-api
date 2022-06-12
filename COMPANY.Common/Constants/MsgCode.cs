namespace COMPANY.Common.Constants
{
    /// <summary>
    /// a class that defines the list of history
    /// MsgCode less than 100 : common
    /// MsgCode >= 100  : Produit
    /// MsgCode >= 200  : payement
    /// MsgCode >= 300  : facture
    /// MsgCode >= 400  : Mail
    /// MsgCode >= 500  : Commercial exchange
    /// MsgCode >= 600  : Dossier
    /// </summary>
    public static class MsgCode
    {
        #region common

        /// <summary>
        /// reference not unique
        /// </summary>
        public const int ReferenceNotUnique = 1;

        /// <summary>
        /// operation failed
        /// </summary>
        public const int OperationFailedException = 2;

        /// <summary>
        /// status incorrect
        /// </summary>
        public const int StatusIncorrect = 3;

        public const int OperationFailedNotFound = 4;

        public const int Unauthorized = 5;

        #endregion

        #region produit

        /// <summary>
        /// the prix produit par agence already exists
        /// </summary>
        public const int PrixProduitParAgenceExist = 100;

        #endregion

        #region Payment

        /// <summary>
        /// the amount of payment invalid
        /// </summary>
        public const int AmountPaymentInvalid = 200;

        /// <summary>
        /// the amount of payment invalid
        /// </summary>
        public const int CantModify = 201;

        #endregion

        #region Facture

        /// <summary>
        /// remove facture payments  
        /// </summary>
        public const int RemovePayment = 300;

        /// <summary>
        /// a devis already associated
        /// </summary>
        public const int DevisAlrealdyAssociated = 301;

        /// <summary>
        /// unacceptable devis for facturation groupe
        /// </summary>
        public const int UnacceptableDevisForFacturationGroupe = 302;

        #endregion

        #region Mail service

        /// <summary>
        /// the configuration of messagerie doesn't exists
        /// </summary>
        public const int NoConfigMessagerie = 400;

        #endregion

        #region commercial exchange

        public const int NoCalendarIdGoogleCalendar = 500;

        #endregion

        #region dossier

        public const int DossierDoesNotHaveStatusSigned = 700;
        public const int ErrorCreateOrderInAntsroute = 701;

        #endregion
    }
}
