namespace COMPANY.Application.Models.General.FilterOptions
{
    using COMPANY.Domain.Enums;
    using System;

    public class DossierFilterOption : FilterOption
    {
        public string ClientId { get; set; }
        public DateTime? DateRdvFrom { get; set; }
        public DateTime? DateRdvTo { get; set; }
        public DossierStatus? Status { get; set; }
    }
}
