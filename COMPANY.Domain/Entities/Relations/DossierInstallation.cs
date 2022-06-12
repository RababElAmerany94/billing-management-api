namespace COMPANY.Domain.Entities
{
    using System;

    /// <summary>
    /// a class that defines a installation of dossier
    /// </summary>
    public class DossierInstallation : Entity<string>
    {
        public DossierInstallation()
        {
            Id = Common.Helpers.IdentityDocument.Generate("DossierInstallation");
        }

        /// <summary>
        /// the date debut de travux of dossier
        /// </summary>
        public DateTime DateDebutTravaux { get; set; }

        /// <summary>
        /// the technicien who install dossier
        /// </summary>
        public User Technicien { get; set; }

        /// <summary>
        /// the id of the technicien who install dossier
        /// </summary>
        public string TechnicienId { get; set; }

        /// <summary>
        /// the dossier associate with this entity
        /// </summary>
        public Dossier Dossier { get; set; }

        /// <summary>
        /// the id of dossier associate with this entity
        /// </summary>
        public string DossierId { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
