namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using Domain.Entities;

    /// <summary>
    /// this model is used when updating the fournisseur
    /// </summary>
    public class FournisseurUpdateModel : FournisseurCreateModel, IEntityUpdateModel<Fournisseur>
    {
        /// <summary>
        /// update the given fournisseur form the current model
        /// </summary>
        /// <param name="fournisseur">the fournisseur to be updated</param>
        public void Update(Fournisseur fournisseur)
        {
            fournisseur.Reference = Reference;
            fournisseur.RaisonSociale = RaisonSociale;
            fournisseur.Contacts = Contacts;
            fournisseur.WebSite = WebSite;
            fournisseur.CodeComptable = CodeComptable;
            fournisseur.Siret = Siret;
            fournisseur.PhoneNumber = PhoneNumber;
            fournisseur.Email = Email;
            fournisseur.Addresses = Addresses;
            fournisseur.Contacts = Contacts;
        }
    }
}
