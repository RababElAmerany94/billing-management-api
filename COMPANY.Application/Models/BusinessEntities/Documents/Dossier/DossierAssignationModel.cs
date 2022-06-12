namespace COMPANY.Application.Models.BusinessEntities.Documents.Dossier
{
    using COMPANY.Domain.Enums;
    using System;
    public class DossierAssignationModel
    {
        /// <summary>
        /// the id of dossier
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the commercial id associate with this dossier
        /// </summary>
        public string CommercialId { get; set; }

        /// <summary>
        /// the date of first RDV of this dossier
        /// </summary>
        public DateTime? DateRDV { get; set; }

        /// <summary>
        /// the status of this dossier
        /// </summary>
        public DossierStatus Status { get; set; }

    }
}
