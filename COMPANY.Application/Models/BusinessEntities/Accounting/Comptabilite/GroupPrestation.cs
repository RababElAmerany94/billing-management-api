namespace COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite
{
    /// <summary>
    /// a class describe group prestation
    /// </summary>
    public class GroupArticles
    {
        /// <summary>
        /// the total HT of category
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// the accounting code of category
        /// </summary>
        public string CodeComptable { get; set; }
    }
}
