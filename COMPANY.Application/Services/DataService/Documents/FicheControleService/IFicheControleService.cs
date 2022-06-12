namespace COMPANY.Application.Services.DataService.Documents.FicheControleService
{
    using COMPANY.Application.Models.BusinessEntities.Documents.FicheControle;
    using COMPANY.Domain.Entities;

    public interface IFicheControleService
        : IBaseService<FicheControle, string, FicheControleModel, FicheControleCreateModel, FicheControleUpdateModel>
    { }
}
