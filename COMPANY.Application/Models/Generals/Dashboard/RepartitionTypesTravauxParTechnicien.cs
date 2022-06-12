namespace COMPANY.Application.Models.Generals.Dashboard
{
    using COMPANY.Domain.Enums;
    using System.Collections.Generic;

    public class RepartitionTypesTravauxParTechnicien
    {
        public string TechnicienId { get; set; }
        public string Technicien { get; set; }
        public double SurfaceTraiter { get; set; }
        public IEnumerable<SurfaceParTypeTravaux> SurfaceParTypeTravaux { get; set; }
    }

    public class SurfaceParTypeTravaux
    {
        public TypeTravaux TypeTravaux { get; set; }
        public double SurfaceTraiter { get; set; }
    }
}
