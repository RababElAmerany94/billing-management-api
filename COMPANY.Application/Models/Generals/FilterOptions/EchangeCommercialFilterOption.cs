using COMPANY.Domain.Enums.EchangeCommercial;
using System;

namespace COMPANY.Application.Models.GeneralModels.PagingModels
{
    /// <summary>
    /// a class describe commercial exchange filter option
    /// </summary>
    public class EchangeCommercialFilterOption : FilterOption
    {
        /// <summary>
        /// the type of echange commercial
        /// </summary>
        public EchangeCommercialType? Type { get; set; }

        /// <summary>
        /// the id of dossier 
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the id of client 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the id of responsable 
        /// </summary>
        public string ResponsableId { get; set; }

        /// <summary>
        /// the category id of agenda commercial 
        /// </summary>
        public string CategorieId { get; set; }

        /// <summary>
        /// the date from
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// the date to
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
