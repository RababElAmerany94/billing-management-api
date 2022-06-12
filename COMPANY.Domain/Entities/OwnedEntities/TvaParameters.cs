namespace COMPANY.Domain.Entities.OwnedEntities
{
    using System.Collections.Generic;

    /// <summary>
    /// a class describe TVA parameters
    /// </summary>
    public class TvaParameters
    {
        public TvaParameters()
        {
            List = new List<TvaModel>();
        }

        /// <summary>
        /// default value of TVA
        /// </summary>
        public int DefaultValue { get; set; }

        /// <summary>
        /// the root of accounting code
        /// </summary>
        public string RootAccountingCode { get; set; }

        /// <summary>
        /// the list of TVA with his accounting code
        /// </summary>
        public List<TvaModel> List { get; set; }
    }

    /// <summary>
    /// a class describe tva model
    /// </summary>
    public class TvaModel
    {
        /// <summary>
        /// the value of TVA
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// the accounting code of tva
        /// </summary>
        public string AccountingCode { get; set; }
    }
}
