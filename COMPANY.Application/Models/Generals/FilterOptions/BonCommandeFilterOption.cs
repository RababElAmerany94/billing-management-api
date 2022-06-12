namespace COMPANY.Application.Models.Generals.FilterOptions
{
    using COMPANY.Domain.Enums.Documents;

    public class BonCommandeFilterOption : FilterOption
    {

        /// <summary>
        /// the status of bon de commande
        /// </summary>
        public BonCommandeStatus? Status { get; set; }
    }
}
