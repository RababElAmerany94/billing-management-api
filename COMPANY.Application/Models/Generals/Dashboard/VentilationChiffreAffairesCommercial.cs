namespace COMPANY.Application.Models.General.Dashboard
{
    using System.Collections.Generic;

    public class VentilationChiffreAffairesCommercial
    {
        public string Commercial { get; set; }
        public string CommercialId { get; set; }
        public decimal TotalHT { get; set; }
        public IEnumerable<ChiffreAffaireParMois> DataParMois { get; set; }
    }

    public class ChiffreAffaireParMois
    {
        public int Month { get; set; }
        public decimal TotalHT { get; set; }
    }
}
