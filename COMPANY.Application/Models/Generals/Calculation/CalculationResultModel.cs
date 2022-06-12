namespace COMPANY.Application.Models.GeneralModels.CalculationModels
{
    using System.Collections.Generic;
    using COMPANY.Domain.Entities.OwnedEntities;

    /// <summary>
    /// a class describe calculation result model
    /// </summary>
    public class CalculationResultModel
    {
        /// <summary>
        /// a list of articles
        /// </summary>
        public List<Article> Articles { get; set; }

        /// <summary>
        /// the total hors tax
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// the list calculation TVA 
        /// </summary>
        public List<CalculationTvaModel> CalculationTvas { get; set; }

        /// <summary>
        /// the total hors tax with discount
        /// </summary>
        public decimal TotalHTRemise { get; set; }

        /// <summary>
        /// the total includes taxes
        /// </summary>
        public decimal TotalTTC { get; set; }
    }

    /// <summary>
    /// a class describe calculation TVA model
    /// </summary>
    public class CalculationTvaModel
    {
        /// <summary>
        /// the TVA value
        /// </summary>
        public decimal TVA { get; set; }

        /// <summary>
        /// the total hors tax
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// the total includes tax
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the total of TVA
        /// </summary>
        public decimal TotalTVA { get; set; }
    }
}
