namespace COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial
{
    using System;

    public class ChangeDateEventModel 
    {
        /// <summary>
        /// the id of commercial exchange
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the date of commercial exchange
        /// </summary>
        public DateTime DateEvent { get; set; }

        /// <summary>
        /// the time of action of commercial exchange
        /// </summary>
        public TimeSpan? Time { get; set; }

        /// <summary>
        /// the duree of commercial exchange
        /// </summary>
        public TimeSpan? Duree { get; set; }
    }
}
