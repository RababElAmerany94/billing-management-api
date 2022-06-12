namespace COMPANY.Domain.Entities.OwnedEntities
{
    /// <summary>
    /// a class describe JSON column prix par quantite
    /// </summary>
    public class PrixParQuantite
    {
        /// <summary>
        /// price in TTC
        /// </summary>
        public decimal Prix { get; set; }

        /// <summary>
        /// the minimal quantity
        /// </summary>
        public double QuantiteMinimal { get; set; }

        /// <summary>
        /// the maximum quantity
        /// </summary>
        public double QuantiteMaximal { get; set; }
    }
}
