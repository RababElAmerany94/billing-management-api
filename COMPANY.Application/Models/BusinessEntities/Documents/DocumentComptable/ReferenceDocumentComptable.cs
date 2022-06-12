namespace COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable
{
    using COMPANY.Application.Enums;

    public class ReferenceDocumentComptable
    {
        /// <summary>
        /// the reference generated
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the current counter of reference
        /// </summary>
        public int? Counter { get; set; }

        /// <summary>
        /// the status of reference
        /// </summary>
        public DocumentComptableReferenceStatus Status { get; set; }

        /// <summary>
        /// is the reference from old accounting period
        /// </summary>
        public bool IsOld { get; set; }
    }
}
