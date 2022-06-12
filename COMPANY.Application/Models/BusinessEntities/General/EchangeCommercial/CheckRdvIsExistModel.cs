namespace COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial
{
    using System;

    /// <summary>
    /// check rdv is exist model
    /// </summary>
    public class CheckRdvIsExistModel
    {
        /// <summary>
        /// the date of commercial exchange
        /// </summary>
        public DateTime DateEvent { get; set; }

        /// <summary>
        /// the time of action of commercial exchange
        /// </summary>
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// the id of the responsible with this commercial exchange
        /// </summary>
        public string ResponsableId { get; set; }

        /// <summary>
        /// the id of the client of this commercial exchange
        /// </summary>
        public string ClientId { get; set; }
    }
}
