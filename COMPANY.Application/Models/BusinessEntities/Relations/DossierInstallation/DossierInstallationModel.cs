namespace COMPANY.Application.Models.BusinessEntitiesModels.DateInstallationSuiviDossierModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using System;

    /// <summary>
    /// a class that defines a Model for <see cref="Domain.Entities.DossierInstallation"/>
    /// </summary>
    public class DossierInstallationModel : EntityModel<string>
    {
        /// <summary>
        /// the date creation of dossier debut du travaux
        /// </summary>
        public DateTime DateDebutTravaux { get; set; }

        /// <summary>
        /// the technicien of this date installation
        /// </summary>
        public UserLiteModel Technicien { get; set; }

        /// <summary>
        /// the id of the technicien of this date installation
        /// </summary>
        public string TechnicienId { get; set; }
    }
}
