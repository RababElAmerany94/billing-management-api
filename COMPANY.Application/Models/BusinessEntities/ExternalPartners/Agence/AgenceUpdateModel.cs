namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// the update model for <see cref="Agence"/>
    /// </summary>
    public class AgenceUpdateModel : AgenceCreateModel, IEntityUpdateModel<Agence>
    {
        /// <summary>
        /// update the agence from the model
        /// </summary>
        /// <param name="agence">the agence to update</param>
        public void Update(Agence agence)
        {
            agence.Reference = Reference;
            agence.RaisonSociale = RaisonSociale;
            agence.FormeJuridique = FormeJuridique;
            agence.Capital = Capital;
            agence.NumeroTvaINTRA = NumeroTvaINTRA;
            agence.Siret = Siret;
            agence.Email = Email;
            agence.IsActive = IsActive;
            agence.PhoneNumber = PhoneNumber;
            agence.CodeComptable = CodeComptable;
            agence.DateDebutActivite = DateDebutActivite;
            agence.DateFinActivite = DateFinActivite;
            agence.AdressesFacturation = AdressesFacturation;
            agence.AdressesLivraison = AdressesLivraison;
            agence.Contacts = Contacts;
            agence.Email = Email;
        }
    }
}
