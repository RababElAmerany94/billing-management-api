namespace COMPANY.Application.Models.Generals.FilterOptions
{
    public class SmsFilterOption : FilterOption
    {
        /// <summary>
        /// the id of client
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the id of dossier
        /// </summary>
        public string DossierId { get; set; }
    }
}
