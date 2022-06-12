namespace COMPANY.Application.Models.BusinessEntities.Documents.Avoir
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;

    /// <summary>
    /// a class describe avoir create model
    /// </summary>
    public class AvoirCreateModel : DocumentComptableCreateModel
    {
        /// <summary>
        /// the status of avoir 
        /// </summary>
        public AvoirStatus Status { get; set; }

        /// <summary>
        /// the type creation of avoir (independent or payment)
        /// </summary>
        public AvoirCreateType Type { get; set; }
    }
}
