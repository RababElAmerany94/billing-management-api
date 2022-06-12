namespace COMPANY.Application.Models.General.Dashboard
{
    using COMPANY.Application.Enums;
    using System;

    public class DashboardFilterOption
    {
        public Period Period { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string ClientId { get; set; }
        public string AgenceId { get; set; }
    }

    public class AdvanceDashboardFilterOption : DashboardFilterOption
    {
        public string UserId { get; set; }
    }

    public class FacturesArticlesByCategoryFilterOption : AdvanceDashboardFilterOption
    {
        public string CategoryId { get; set; }
    }
}
