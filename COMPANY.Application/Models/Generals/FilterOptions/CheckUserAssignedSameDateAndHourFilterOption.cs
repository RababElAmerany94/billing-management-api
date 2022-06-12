namespace COMPANY.Application.Models.General.FilterOptions
{
    using System;

    public class CheckUserAssignedSameDateAndHourFilterOption
    {
        public DateTime DateRdv { get; set; }
        public string UserId { get; set; }
        public string ExcludeDossierId { get; set; }
    }
}
