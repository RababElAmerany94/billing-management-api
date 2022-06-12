namespace COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels
{
    using COMPANY.Domain.Enums;

    /// <summary>
    /// the <see cref="Domain.Entities.Numerotation"/> Create Model
    /// </summary>
    public class NumerotationCreateModel
    {
        /// <summary>
        /// the root of the numerotation
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// the date format the numerotation
        /// </summary>
        public DateFormat DateFormat { get; set; }

        /// <summary>
        /// the current counter of numerotation
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        /// the counter length of numerotation
        /// </summary>
        public int? CounterLength { get; set; }

        /// <summary>
        /// the type of numerotation <see cref="NumerotationType"/>
        /// </summary>
        public NumerotationType Type { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }
    }
}
