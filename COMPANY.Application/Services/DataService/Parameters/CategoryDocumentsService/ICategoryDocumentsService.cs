namespace COMPANY.Application.Services.DataService.CategoryDocumentsService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryDocumentsModels;
    using COMPANY.Domain.Entities.Parameters;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="CategoryDocuments"/> Entity
    /// </summary>
    public interface ICategoryDocumentsService : IBaseService<CategoryDocuments, string, CategoryDocumentModel, CategoryDocumentCreateModel, CategoryDocumentUpdateModel>
    {
        /// <summary>
        /// check if the there is any category document with the given name
        /// </summary>
        /// <param name="name">the name of Category Document</param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
