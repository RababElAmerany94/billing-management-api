namespace COMPANY.Domain.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// a class that defines the Country entity
    /// </summary>
    public class Country : Entity<string>
    {
        public Country()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Country");
            Departements = new HashSet<Departement>();
        }

        public int Code { get; set; }

        public string NomEnGb { get; set; }

        public string NomFrFr { get; set; }

        public ICollection<Departement> Departements { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }

    /// <summary>
    /// a class that defines the states entity
    /// </summary>
    public class Departement : Entity<string>
    {
        public Departement()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Departement");
        }

        public string DepartementCode { get; set; }

        public string DepartementNom { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }
}
