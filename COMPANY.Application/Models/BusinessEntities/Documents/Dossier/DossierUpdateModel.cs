namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe <see cref="Dossier"/> update model
    /// </summary>
    public class DossierUpdateModel : DossierCreateModel, IEntityUpdateModel<Dossier>
    {
        /// <summary>
        /// update the dossier from the current dossier model
        /// </summary>
        /// <param name="dossier">the dossier instant to be updated</param>
        public void Update(Dossier dossier)
        {
            dossier.Reference = Reference;
            dossier.DatePose = DatePose;
            dossier.DateCreation = DateCreation;
            dossier.DateExpiration = DateExpiration;
            dossier.FirstPhoneNumber = FirstPhoneNumber;
            dossier.SecondPhoneNumber = SecondPhoneNumber;
            dossier.Status = Status;
            dossier.Note = Note;
            dossier.ClientId = ClientId;
            dossier.PrimeCEEId = PrimeCEEId;
            dossier.SourceLeadId = SourceLeadId;
            dossier.DateReceptionLead = DateReceptionLead;
            dossier.LogementTypeId = LogementTypeId;
            dossier.TypeChauffageId = TypeChauffageId;
            dossier.ParcelleCadastrale = ParcelleCadastrale;
            dossier.SurfaceTraiter = SurfaceTraiter;
            dossier.NombrePersonne = NombrePersonne;
            dossier.IsMaisonDePlusDeDeuxAns = IsMaisonDePlusDeDeuxAns;
            dossier.Precarite = Precarite;
            dossier.RevenueFiscaleReference = RevenueFiscaleReference;
            dossier.NumeroAH = NumeroAH;
            dossier.TypeTravaux = TypeTravaux;
            dossier.DateRDV = DateRDV;
            dossier.CommercialId = CommercialId;
            dossier.RaisonAnnulation = RaisonAnnulation;
            dossier.SiteInstallationInformationsSupplementaire = SiteInstallationInformationsSupplementaire;
        }
    }
}
