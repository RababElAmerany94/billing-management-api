namespace COMPANY.Application.Services.DataService
{
    using Application.Models;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="Domain.Entities.Fournisseur"/> Entity
    /// </summary>
    public interface IFournisseurService :
        IBaseService<Fournisseur, string, FournisseurModel, FournisseurCreateModel, FournisseurUpdateModel>
    {
        /// <summary>
        /// export the list of fournisseur as an excel file
        /// </summary>
        /// <returns>the result instant</returns>
        Task<Result<byte[]>> ExportFournisseurListAsExcelAsync();

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);
    }
}
