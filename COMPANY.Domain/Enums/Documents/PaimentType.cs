namespace COMPANY.Domain.Enums
{
    /// <summary>
    /// a enum describe type creation of avoir
    /// </summary>
    public enum PaiementType
    {
        /// <summary>
        /// normal payment
        /// </summary>
        Payer = 1,
        /// <summary>
        /// payment group of factures
        /// </summary>
        PayerGroup = 2,
        /// <summary>
        /// transfer money from
        /// </summary>
        TransferFrom = 3,
        /// <summary>
        /// transfer money to
        /// </summary>
        TransferTo = 4,
        /// <summary>
        /// paymenet by avoir
        /// </summary>
        ByAvoir = 5
    }
}
