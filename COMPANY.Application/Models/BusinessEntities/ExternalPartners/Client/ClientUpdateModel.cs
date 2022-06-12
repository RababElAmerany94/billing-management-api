namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// the class that represent the update model for the client
    /// </summary>
    public class ClientUpdateModel : ClientCreateModel, IEntityUpdateModel<Client>
    {
        /// <summary>
        /// update the client from the current Client Model
        /// </summary>
        /// <param name="client">the client instant to be updated</param>
        public void Update(Client client)
        {
            client.Reference = Reference;
            client.FirstName = FirstName;
            client.LastName = LastName;
            client.PhoneNumber = PhoneNumber;
            client.Email = Email;
            client.WebSite = WebSite;
            client.Siret = Siret;
            client.CodeComptable = CodeComptable;
            client.Type = Type;
            client.Addresses = Addresses;
            client.Contacts = Contacts;
            client.SourceLeadId = SourceLeadId;
            client.DateReceptionLead = DateReceptionLead;
            client.LogementTypeId = LogementTypeId;
            client.TypeChauffageId = TypeChauffageId;
            client.ParcelleCadastrale = ParcelleCadastrale;
            client.SurfaceTraiter = SurfaceTraiter;
            client.NombrePersonne = NombrePersonne;
            client.IsMaisonDePlusDeDeuxAns = IsMaisonDePlusDeDeuxAns;
            client.Precarite = Precarite;
            client.RevenueFiscaleReference = RevenueFiscaleReference;
            client.NumeroAH = NumeroAH;
            client.TypeTravaux = TypeTravaux;
            client.LabelPrimeCEE = LabelPrimeCEE;
            client.NoteDevis = NoteDevis;
            client.PrimeCEEId = PrimeCEEId;
            client.RegulationModeId = RegulationModeId;
            client.AgenceId = AgenceId;
            client.Genre = Genre;
            client.IsSousTraitant = IsSousTraitant;
            client.Origin = Origin;
        }
    }
}
